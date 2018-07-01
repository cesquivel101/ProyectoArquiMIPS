using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using ProyectoArquitectura.Memorias;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ProyectoArquitectura
{
    //QUien hace los cambios de contexto? ==> hilo de control
    //La idea es tener una doble barrera para la sincronizacion de los ciclos en los hilos que corren hilillos
    // Cuando llegamos a la primera barrera solo el hilo de control hace cosas de sincronizacion y ver que se cambia de contexto y asi
    //

    /// <summary>
    /// Clase que modela la simulacion de un procesador mips
    /// </summary>
    public class Proceso
    {
        Memoria mem;
        List<Contexto> contexto;
        List<Contexto> contextoFinal;
        Nucleo nucleo0;
        Nucleo nucleo1;
        Bus busDatos;
        Bus busInstrucciones;

        //Si tenemos solo un reloj aca o si tenemos el valor en el nucleo como una lista.
        int reloj;

        public Proceso()
        {
            this.mem = new Memoria();
            this.contexto = new List<Contexto>();
            this.nucleo0 = new Nucleo();
            this.nucleo1 = new Nucleo();
            busDatos = new Bus();
            busInstrucciones = new Bus();
            this.contextoFinal = new List<Contexto>();

            reloj = 0;
            List<string> nombresHilillos = Misc.leerNombresHilillos();
            inicializarMemoria(nombresHilillos);
        }

        public void iniciarProceso()
        {
            mem.Imprimir();

            foreach (Contexto c in contexto)
            {
                c.imprimir();
            }

            //iniciarHilo(ref nucleo0);

            //nucleo0.RegistroInstruccion.imprimir();

            //Thread principal = Thread.CurrentThread;
            //principal.Name = "Principal";

            //Contexto contextoActual0 = contexto[0];
            //contexto.RemoveAt(0);

            //ThreadStart hiloNucleo0Ref = new ThreadStart(() => iniciarHilo(ref nucleo0,ref contextoActual0));
            //Thread hiloNucleo0 = new Thread(hiloNucleo0Ref);
            //hiloNucleo0.Start();

            //Contexto contextoActual1 = contexto[0];
            //contexto.RemoveAt(0);
            //ThreadStart hiloNucleo1Ref = new ThreadStart(() => iniciarHilo(ref nucleo1,ref contextoActual1));
            //Thread hiloNucleo1 = new Thread(hiloNucleo1Ref);
            //hiloNucleo1.Start();

            /*Si ya se termino el quantum, hay que guardar el contexto*/
            //if (true)
            //{
            //    contextoActual.Registros = nucleo.Registros;
            //    contextoActual.PC = nucleo.PC;
            //    contexto.Add(contextoActual);
            //}

        }

        //TODO: cambiar el nombre del metodo
        /// <summary>
        /// Metodo que se encarga de poner una instruccion de la memoria de instrucciones en cache y luego en el IR del nucleo que entra como parametro
        /// </summary>
        /// <param name="nucleo">nucleo a utilizar</param>
        /// <param name="contextoActual">Instrucciones de los hilillos a ejecutar</param>
        public void iniciarHilo(ref Nucleo nucleo,ref Contexto contextoActual)
        {
            //ir a memoria y cargar la instruccion
            //Cargar el contexto
            nucleo.PC = contextoActual.PC;
            while (nucleo.PC != -1/*si se termino el quantum*/)
            {

                int bloqueMemoria = (nucleo.PC - Constantes.Posicion_Inicial_Memoria_instrucciones) / Constantes.Cache_Instrucciones_Tamanio_Bloque;
                int palabra = ((nucleo.PC - Constantes.Posicion_Inicial_Memoria_instrucciones) % Constantes.Cache_Instrucciones_Tamanio_Bloque) / Constantes.Numero_Bloques_Cache;
                int posicionEnCache = bloqueMemoria % Constantes.Numero_Bloques_Cache;

                if (nucleo.CacheInstrucciones.Bloques[posicionEnCache].Etiqueta != bloqueMemoria ||
                    nucleo.CacheInstrucciones.Bloques[posicionEnCache].Estado == Constantes.Estado_Invalido)
                {
                    //subir bloque de memoria a cache
                    while (busInstrucciones.Bloqueado)
                    {
                        //probablemente haya que aumentar ciclos de reloj
                    }
                    busInstrucciones.Bloqueado = true;
                    //Esto sube un bloque de memoria de instrucciones a cache
                    nucleo.CacheInstrucciones.Bloques[posicionEnCache].Bloque = mem.Instrucciones[bloqueMemoria];
                    nucleo.CacheInstrucciones.Bloques[posicionEnCache].Etiqueta = bloqueMemoria;
                    nucleo.CacheInstrucciones.Bloques[posicionEnCache].Estado = Constantes.Estado_Compartido;
                    //
                    busInstrucciones.Bloqueado = false;
                }

                nucleo.RegistroInstruccion = nucleo.CacheInstrucciones.Bloques[posicionEnCache].Bloque.Instrucciones[palabra];

                //Esto probablemente deberia ir fuera de este metodo
                ProcesadorInstrucciones.procesarInstruccion(ref nucleo);

                //nucleo.CacheInstrucciones.imprimir();
            }
            //nucleo.imprimirRegistros();
        }

        /// <summary>
        /// Metodo que lee los hilillos de los archivos de texto y los pone en memoria de instrucciones
        /// Si nombresHIlillos es nulo, lee todos los .txt del root
        /// </summary>
        /// <param name="nombresHilillos">nombres de los hilillos a leer</param>
        private void inicializarMemoria(List<string> nombresHilillos = null)
        {
            List<string> todosBytes =nombresHilillos == null? LectorHilillos.leerHilillos() : LectorHilillos.leerHilillos(nombresHilillos);
            inicializarMemoriaDatos();
            inicializarMemoriaInstrucciones(todosBytes);
            inicializarContexto(todosBytes);

        }

        /// <summary>
        /// Metodo que toma una hiliera con todas las instrucciones de los hilillos y las pone en memoria
        /// </summary>
        /// <param name="todosBytes">todas las instrucciones leidas de todos los hilillos</param>
        private void inicializarMemoriaInstrucciones(List<string> todosBytes)
        {

            int cantidadDeValoresXBloque = Constantes.Num_Valores_X_Palabra_Instruccion * Constantes.Num_Palabras_X_Bloque;
            for (int j = 0; j < todosBytes.Count; j += cantidadDeValoresXBloque)
            {
                List<IR> bloquesNuevos = new List<IR>();
                for (int i = 0; i < cantidadDeValoresXBloque; i+= Constantes.Num_Valores_X_Palabra_Instruccion)
                {
                    int posicionBytes = j + i;

                    if (posicionBytes < todosBytes.Count)
                    {
                        IR nuevo = new IR(Int32.Parse(todosBytes[posicionBytes]),
                                          Int32.Parse(todosBytes[posicionBytes+1]),
                                          Int32.Parse(todosBytes[posicionBytes+2]),
                                          Int32.Parse(todosBytes[posicionBytes+3]));
                        bloquesNuevos.Add(nuevo);
                    }
                    else
                    {
                        i = cantidadDeValoresXBloque;
                        j = todosBytes.Count;
                    }
                }
                this.mem.Instrucciones.Add(new BloqueInstrucciones(bloquesNuevos));
            }

        }

        /// <summary>
        /// Metodo que inicializa el contexto con los hilillos
        /// </summary>
        /// <param name="todosBytes"></param>
        private void inicializarContexto(List<string> todosBytes)
        {
            int posicionInicialPC = Constantes.Posicion_Inicial_Memoria_instrucciones;
            int contadorIdsHilillos = 0;
            int posicionInstruccionFinalHilillo = -1;
            List<int> indiceDeFinalizacionesDeHilo = Misc.TodosLosIndices(Constantes.Codigo_Fin, todosBytes);
            for (int i = 0; i < indiceDeFinalizacionesDeHilo.Count; i++)
            {
                if (i != 0)
                {
                    posicionInicialPC = Constantes.Posicion_Inicial_Memoria_instrucciones + indiceDeFinalizacionesDeHilo[i - 1] + Constantes.Num_Valores_X_Palabra_Instruccion;
                }
                posicionInstruccionFinalHilillo = indiceDeFinalizacionesDeHilo[i] + Constantes.Posicion_Inicial_Memoria_instrucciones;
                Contexto nuevo = new Contexto(posicionInicialPC, contadorIdsHilillos, posicionInstruccionFinalHilillo);
                contadorIdsHilillos++;
                contexto.Add(nuevo);
            }
        }

        /// <summary>
        /// Metodo que inicializa la memoria de datos con 1's
        /// </summary>
        private void inicializarMemoriaDatos()
        {
            for (int i = 0; i < Constantes.Numero_Bloques_Memoria_Datos; i++)
            {
                string[] datos = new string[] { "1", "1", "1", "1" };
                mem.Datos.Add(new BloqueDatos(datos));
            }
        }
    }
}

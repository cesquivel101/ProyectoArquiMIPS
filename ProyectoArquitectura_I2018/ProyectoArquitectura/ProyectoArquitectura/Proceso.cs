using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using ProyectoArquitectura.Memorias;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProyectoArquitectura
{
    //QUien hace los cambios de contexto? ==> hilo de control
    //La idea es tener una doble barrera para la sincronizacion de los ciclos en los hilos que corren hilillos
    // Cuando llegamos a la primera barrera solo el hilo de control hace cosas de sincronizacion y ver que se cambia de contexto y asi
    //


    public class Proceso
    {
        Memoria mem;
        List<Contexto> contexto;
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
            this.nucleo0 = new Nucleo(Constantes.Numero_Bloques_Nucleo_0, Constantes.Numero_Hilos_Bloque_0);
            this.nucleo1 = new Nucleo(Constantes.Numero_Bloques_Nucleo_1,Constantes.Numero_Hilos_Bloque_1);
            busDatos = new Bus();
            busInstrucciones = new Bus();

            reloj = 0;

            inicializarMemoria();
        }

        public void iniciarProceso()
        {
            mem.Imprimir();

            foreach (Contexto c in contexto)
            {
                c.imprimir();
            }
        }

        private void inicializarMemoria()
        {
            List<string> todosBytes = LectorHilillos.leerHilillos();
            inicializarMemoriaDatos();
            inicializarMemoriaInstrucciones(todosBytes);
            inicializarContexto(todosBytes);

        }

        private void inicializarMemoriaInstrucciones(List<string> todosBytes)
        {
            
            int cantidadDeValoresXBloque = Constantes.Num_Valores_X_Palabra_Instruccion * Constantes.Num_Palabras_X_Bloque;
            for(int j = 0; j < todosBytes.Count;j+=cantidadDeValoresXBloque)
            {
                string[] nuevoBloque = new string[cantidadDeValoresXBloque];
                for (int i = 0; i < cantidadDeValoresXBloque; i++)
                {
                    //Este calculo esta mal
                    int posicionBytes = j + i;
                    if (posicionBytes < todosBytes.Count)
                    {
                        nuevoBloque[i] = todosBytes[posicionBytes];
                    }
                    else
                    {
                        i = cantidadDeValoresXBloque;
                        j = todosBytes.Count;
                    }
                }
                this.mem.Instrucciones.Add(new Bloque(nuevoBloque));
            }

        }

        private void inicializarContexto(List<string> todosBytes)
        {
            int posicionInicialPC = Constantes.Posicion_Inicial_Memoria_instrucciones;
            int contadorIdsHilillos = 0;
            int posicionInstruccionFinalHilillo = -1;
            List<int> indiceDeFinalizacionesDeHilo = Misc.TodosLosIndices(Constantes.Codigo_Fin,todosBytes);
            for (int i = 0; i < indiceDeFinalizacionesDeHilo.Count; i++)
            {
                if (i != 0)
                {
                    posicionInicialPC = Constantes.Posicion_Inicial_Memoria_instrucciones + indiceDeFinalizacionesDeHilo[i-1]+Constantes.Num_Valores_X_Palabra_Instruccion;
                }
                posicionInstruccionFinalHilillo = indiceDeFinalizacionesDeHilo[i]+Constantes.Posicion_Inicial_Memoria_instrucciones;
                Contexto nuevo = new Contexto(posicionInicialPC, contadorIdsHilillos, posicionInstruccionFinalHilillo);
                contadorIdsHilillos++;
                contexto.Add(nuevo);
            }
        }

        private void inicializarMemoriaDatos()
        {
            for (int i = 0; i < Constantes.Numero_Bloques_Memoria_Datos; i++)
            {
                string[] datos = new string[] { "1", "1", "1", "1" };
                mem.Datos.Add(new Bloque(datos));
            }
        }


    }
}

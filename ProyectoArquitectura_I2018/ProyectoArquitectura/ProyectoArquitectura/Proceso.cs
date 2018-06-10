using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using ProyectoArquitectura.Memorias;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProyectoArquitectura
{
    public class Proceso
    {
        Memoria mem;
        List<Contexto> contexto;
        Nucleo nucleo0;
        Nucleo nucleo1;
        Bus busDatos;
        Bus busInstrucciones;
        public Proceso()
        {
            this.mem = new Memoria();
            this.contexto = new List<Contexto>();
            this.nucleo0 = new Nucleo(Constantes.Numero_Hilos_Bloque_0);
            this.nucleo1 = new Nucleo(Constantes.Numero_Hilos_Bloque_1);
            busDatos = new Bus();
            busInstrucciones = new Bus();

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

        //private void inicializarMemoriaInstrucciones()
        //{
        //    string currentDir = Directory.GetCurrentDirectory();
        //    string previousDir = currentDir.Substring(0, currentDir.LastIndexOf('\\'));
        //    DirectoryInfo di = new DirectoryInfo(previousDir);
        //    int posicionActualMemoriaInstrucciones = Constantes.Posicion_Inicial_Memoria_instrucciones;
        //    int posicionInicialPC = Constantes.Posicion_Inicial_Memoria_instrucciones;
        //    int contadorIdsHilillos = 0;
        //    foreach (var file in di.GetFiles("*.txt"))
        //    {
        //        List<Bloque> instrucciones = LectorHilillos.leerHilillo(file.FullName);
        //        posicionActualMemoriaInstrucciones += instrucciones.Count * Constantes.Num_Palabras_X_Bloque * Constantes.Num_Valores_X_Palabra_Instruccion;
        //        int posicionInstruccionFinal = posicionActualMemoriaInstrucciones - Constantes.Num_Valores_X_Palabra_Instruccion;
        //        contexto.Add(new Contexto(posicionInicialPC,contadorIdsHilillos, posicionInstruccionFinal));
        //        mem.Instrucciones.AddRange(instrucciones);
        //        posicionInicialPC = posicionActualMemoriaInstrucciones;
        //        //printHilillo(instrucciones);
        //    }
        //}

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
                string[] datos = new string[] { "-1", "-1", "-1", "-1" };
                mem.Datos.Add(new Bloque(datos));
            }
        }


    }
}

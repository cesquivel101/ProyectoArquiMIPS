﻿using ProyectoArquitectura.Bloques;
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
            this.nucleo0 = new Nucleo();
            this.nucleo1 = new Nucleo();
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

            iniciarHilo(ref nucleo0);

            nucleo0.RegistroInstruccion.imprimir();

            //Thread principal = Thread.CurrentThread;
            //principal.Name = "Principal";

            //ThreadStart hiloNucleo0Ref = new ThreadStart(() => iniciarHilo(ref nucleo0));
            //Thread hiloNucleo0 = new Thread(hiloNucleo0Ref);

            //ThreadStart hiloNucleo1Ref = new ThreadStart(() => iniciarHilo(ref nucleo1));
            //Thread hiloNucleo1 = new Thread(hiloNucleo1Ref);

        }

        public void iniciarHilo(ref Nucleo nucleo)
        {
            //ir a memoria y cargar la instruccion
            //Cargar el contexto
            Contexto contextoActual = contexto[0];
            contexto.RemoveAt(0);

            nucleo.PC = contextoActual.PC;

            //No estoy seguro que sea entre 4
            //int bloqueInstruccionMemoria = (nucleo.PC - Constantes.Posicion_Inicial_Memoria_instrucciones) / Constantes.Numero_Bloques_Cache;
            //int bloqueInstruccionCache = bloqueInstruccionMemoria % Constantes.Numero_Bloques_Cache;

            int bloqueMemoria = (nucleo.PC - Constantes.Posicion_Inicial_Memoria_instrucciones) / 16; //Poner 16 en constante
            int palabra = ((nucleo.PC - Constantes.Posicion_Inicial_Memoria_instrucciones) % 16) / Constantes.Numero_Bloques_Cache;
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
            for (int j = 0; j < todosBytes.Count; j += cantidadDeValoresXBloque)
            {
                List<IR> bloquesNuevos = new List<IR>();
                //string[] nuevoBloque = new string[cantidadDeValoresXBloque];
                for (int i = 0; i < cantidadDeValoresXBloque; i+= Constantes.Num_Valores_X_Palabra_Instruccion)
                {
                    int posicionBytes = j + i;
                    
                    //for (int k= 0;k < Constantes.Num_Valores_X_Palabra_Instruccion;k++)

                    //Este calculo esta mal
                    //int posicionBytes = j + i;
                    if (posicionBytes < todosBytes.Count)
                    {
                        IR nuevo = new IR(Int32.Parse(todosBytes[posicionBytes]),
                                          Int32.Parse(todosBytes[posicionBytes+1]),
                                          Int32.Parse(todosBytes[posicionBytes+2]),
                                          Int32.Parse(todosBytes[posicionBytes+3]));
                        bloquesNuevos.Add(nuevo);
                        //nuevoBloque[i] = todosBytes[posicionBytes];
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

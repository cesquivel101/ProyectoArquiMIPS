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
           
        }

        private void inicializarMemoria()
        {
            inicializarMemoriaDatos();
            inicializarMemoriaInstrucciones();

        }

        private void inicializarMemoriaInstrucciones()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string previousDir = currentDir.Substring(0, currentDir.LastIndexOf('\\'));
            DirectoryInfo di = new DirectoryInfo(previousDir);
            int posicionActualMemoriaInstrucciones = Constantes.Posicion_Inicial_Memoria_instrucciones;
            int contadorIdsHilillos = 0;
            foreach (var file in di.GetFiles("*.txt"))
            {
                List<Bloque> instrucciones = LectorHilillos.leerHilillo(file.FullName);
                posicionActualMemoriaInstrucciones += instrucciones.Count * Constantes.Num_Palabras_X_Bloque * Constantes.Num_Valores_X_Palabra_Instruccion;
                int posicionInstruccionFinal = posicionActualMemoriaInstrucciones - Constantes.Num_Valores_X_Palabra_Instruccion;
                contexto.Add(new Contexto(contadorIdsHilillos, posicionInstruccionFinal));
                mem.Instrucciones.AddRange(instrucciones);
                //printHilillo(instrucciones);
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

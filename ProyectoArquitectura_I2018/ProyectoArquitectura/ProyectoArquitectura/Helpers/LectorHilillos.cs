using ProyectoArquitectura.Bloques;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ProyectoArquitectura.Helpers
{
    public class LectorHilillos
    {
        public static List<string> leerHilillos()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string previousDir = currentDir.Substring(0, currentDir.LastIndexOf('\\'));
            DirectoryInfo di = new DirectoryInfo(previousDir);
            List<string> todosBytes = new List<string>();
            foreach (var file in di.GetFiles("*.txt"))
            {
                List<string> instruccionesHilillo = leerArchivo(file.FullName);
                foreach (string ins in instruccionesHilillo)
                {
                    todosBytes.AddRange(ins.Split(' '));
                }
                
            }
            return todosBytes;
        }

        //Espacio para mejora
        //private static List<Bloque> parsearInstrucciones(List<string> instruccionesHilillo)
        //{
        //    int cantidadDeValoresXBloque = Constantes.Num_Valores_X_Palabra_Instruccion * Constantes.Num_Palabras_X_Bloque;
        //    List<Bloque> instruccionesParseadas = new List<Bloque>();
        //    for(int j = 0; j < instruccionesHilillo.Count; j+= Constantes.Num_Valores_X_Palabra_Instruccion)
        //    {

        //        string[] insParseada = new string[cantidadDeValoresXBloque];

        //        for (int i = 0; i < Constantes.Num_Palabras_X_Bloque; i++)
        //        {
        //            int posicionInstruccionHilillo = j + i;
        //            if (posicionInstruccionHilillo < instruccionesHilillo.Count)
        //            {
        //                string[] insActual = instruccionesHilillo[posicionInstruccionHilillo].Split(' ');
        //                for (int k = 0; k < insActual.Length; k++)
        //                {
        //                    int posicion = i * insActual.Length + k;
        //                    insParseada[posicion] = insActual[k];
        //                }
        //            }
        //            else
        //            {
        //                i = Constantes.Num_Palabras_X_Bloque;
        //            }

        //        }
        //        instruccionesParseadas.Add(new Bloque(insParseada));
        //    }
        //    return instruccionesParseadas;
        //}

        //private static List<string> leerInstrucciones(List<string> instruccionesHilillo)
        //{
        //    int cantidadDeValoresXBloque = Constantes.Num_Valores_X_Palabra_Instruccion * Constantes.Num_Palabras_X_Bloque;
        //    List<string> instrucciones = new List<string>();
        //    foreach (string ins in instruccionesHilillo)
        //    {
        //        instrucciones.Add(instruccionesHilillo);
        //    }
        //    return instruccionesParseadas;
        //}

        /// <summary>
        /// Separador por cambio de linea
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        private static List<string> leerArchivo(string ruta)
        {
            string text = File.ReadAllText(ruta);
            List<string> instruccionesHilillo = text.Split('\n').ToList();
            return instruccionesHilillo;
        }

    }
}

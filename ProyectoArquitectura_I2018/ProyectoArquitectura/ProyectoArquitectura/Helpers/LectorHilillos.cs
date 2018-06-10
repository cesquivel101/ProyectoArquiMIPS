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
        public static List<Bloque> leerHilillo(string rutaArchivo)
        {
            List<Bloque> instrucciones = parsearInstrucciones(leerArchivo(rutaArchivo));
            return instrucciones;
        }

        private static List<Bloque> parsearInstrucciones(List<string> instruccionesHilillo)
        {
            int cantidadDeValoresXBloque = Constantes.Num_Valores_X_Palabra_Instruccion * Constantes.Num_Palabras_X_Bloque;
            List<Bloque> instruccionesParseadas = new List<Bloque>();
            for(int j = 0; j < instruccionesHilillo.Count; j+= Constantes.Num_Valores_X_Palabra_Instruccion)
            {
                string[] insParseada = new string[cantidadDeValoresXBloque];

                for (int i = 0; i < Constantes.Num_Palabras_X_Bloque; i++)
                {
                    string[] insActual = instruccionesHilillo[j + i].Split(' ');
                    foreach (string actual in insActual)
                    {
                        insParseada[i] = actual;
                    }
                    
                }
                instruccionesParseadas.Add(new Bloque(insParseada));
            }
            return instruccionesParseadas;
        }

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

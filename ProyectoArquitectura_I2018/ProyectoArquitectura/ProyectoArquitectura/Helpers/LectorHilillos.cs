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
                    int posicionInstruccionHilillo = j + i;
                    if (posicionInstruccionHilillo < instruccionesHilillo.Count)
                    {
                        string[] insActual = instruccionesHilillo[posicionInstruccionHilillo].Split(' ');
                        for (int k = 0; k < insActual.Length; k++)
                        {
                            int posicion = i * insActual.Length + k;
                            insParseada[posicion] = insActual[k];
                        }
                    }
                    else
                    {
                        for (int k = 0; k < Constantes.Num_Valores_X_Palabra_Instruccion; k++)
                        {
                            int posicion = i * Constantes.Num_Valores_X_Palabra_Instruccion + k;
                            insParseada[posicion] = "-1";
                        }
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

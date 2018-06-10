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
            List<Bloque> instruccionesParseadas = new List<Bloque>();
            foreach (string instruccion in instruccionesHilillo)
            {
                string[] insParseada = instruccion.Split(' ');
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

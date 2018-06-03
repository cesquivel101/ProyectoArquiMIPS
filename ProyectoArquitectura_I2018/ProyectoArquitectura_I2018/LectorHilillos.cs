using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ProyectoArquitectura_I2018
{
    public class LectorHilillos
    {
        public static List<Instruccion> leerHilillo(string rutaArchivo)
        {
            List<Instruccion> instrucciones = parsearInstrucciones(leerArchivo(rutaArchivo));
            return instrucciones;
        }

        private static List<Instruccion> parsearInstrucciones(List<string> instruccionesHilillo)
        {
            List<Instruccion> instruccionesParseadas = new List<Instruccion>();
            foreach (string instruccion in instruccionesHilillo)
            {
                string[] insParseada = instruccion.Split(' ');
                int co = Int32.Parse(insParseada[0]);
                int rf1 = Int32.Parse(insParseada[1]);
                int rf2_rd = Int32.Parse(insParseada[2]);
                int rd_Inm = Int32.Parse(insParseada[3]);

                instruccionesParseadas.Add(new Instruccion(co, rf1,rf2_rd,rd_Inm));
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

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

        /// <summary>
        /// Lee los archivos de texto pasados por parametro (nombres)
        /// </summary>
        /// <param name="nombres">nombres de los archivos a leer</param>
        /// <returns>Una lista de hileras con todas las instrucciones a ejecutar</returns>
        public static List<string> leerHilillos(List<string> nombres)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string previousDir = currentDir.Substring(0, currentDir.LastIndexOf('\\'));
            DirectoryInfo di = new DirectoryInfo(previousDir);
            List<string> todosBytes = new List<string>();
            //foreach (var file in di.GetFiles("*.txt"))
            foreach(string nombre in nombres)
            {
                var file = di.GetFiles(nombre + ".txt").FirstOrDefault();
                List<string> instruccionesHilillo = leerArchivo(file.FullName);
                foreach (string ins in instruccionesHilillo)
                {
                    todosBytes.AddRange(ins.Split(' '));
                }

            }
            return todosBytes;
        }

        /// <summary>
        /// Lee todos los hilillos (archivos de texto) en el root de la solucion
        /// </summary>
        /// <returns>Una lista de hileras con todas las instrucciones a ejecutar</returns>
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

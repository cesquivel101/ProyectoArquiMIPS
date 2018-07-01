using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProyectoArquitectura.Memorias;

namespace ProyectoArquitectura.Helpers
{
    /// <summary>
    /// Clase con metodos utilitarios
    /// </summary>
    public static class Misc
    {
        /// <summary>
        /// Metodo que devuelve todos los indices en los que aBuscar esta presente en una lista
        /// </summary>
        /// <param name="aBuscar">hilera a buscar dentro de lista</param>
        /// <param name="listaObjetivo">lista de la cual sacar los indices</param>
        /// <returns></returns>
        public static List<int> TodosLosIndices(string aBuscar, List<string> listaObjetivo)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < listaObjetivo.Count; i++)
            {
                if (listaObjetivo[i].Equals(aBuscar))
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        /// <summary>
        /// Metodo que lee los hilillos a poner en memoria
        /// </summary>
        /// <returns>Lista de nombres de los hilillos</returns>
        public static List<string> leerNombresHilillos()
        {
            List<string> nombres = new List<string>();

            Console.WriteLine("Digite los nombres de los hilillos(sin el .txt) separados por espacio y presione enter");
            Console.WriteLine("Ejemplo:'0 1 2'");
            string entradaUsuario = Console.ReadLine();
            nombres = entradaUsuario.Split(' ').ToList();
            return nombres;
        }

        public static int leerQuantum()
        {
            int quantum = -1;
            Console.Write("Por favor digite el quantum deseado y luego presione enter: ");
            string entradaUsuario = Console.ReadLine();
            quantum = Int32.Parse(entradaUsuario);
            return quantum;

        }

        public static void imprimirEjecucionLenta(int reloj, Nucleo n0, Nucleo n1)
        {
            Console.WriteLine("Reloj: " + reloj.ToString());
            Console.WriteLine("Hilillos en ejecucion:");
            Console.WriteLine("\t - Nucleo 0:" + n0.IDHililloEjecutandose);
            Console.WriteLine("\t - Nucleo 1:" + n1.IDHililloEjecutandose);
        }

        public static void impresionFinal(Memoria memoria,Nucleo n0, Nucleo n1,Contexto contexto)
        {
            Console.WriteLine("-------------------");
            memoria.impresionFinal();
            Console.WriteLine("Cache de Datos Nucleo 0:");
            n0.CacheDatos.impresionFinal();
            Console.WriteLine("Cache de Datos Nucleo 1:");
            n1.CacheDatos.impresionFinal();
            contexto.impresionFinal();
            Console.WriteLine("-------------------");

        }
        
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    public class BloqueDatos
    {
        public List<int> Palabras { get; set; }

        public BloqueDatos()
        {
            this.Palabras = new List<int>();
        }

        public BloqueDatos(string[] palabras)
        {
            this.Palabras = new List<int>();
            foreach (string pal in palabras)
            {
                this.Palabras.Add(Int32.Parse(pal));
            }
        }

        public void imprimir()
        {
            Console.Write("Palabra: ");
            foreach (int _byte in Palabras)
            {
                Console.Write(_byte.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}

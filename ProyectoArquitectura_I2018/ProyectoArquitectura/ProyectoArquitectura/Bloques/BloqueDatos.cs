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
            this.Palabras[0] = Int32.Parse(palabras[0]);
            this.Palabras[1] = Int32.Parse(palabras[1]);
            this.Palabras[1] = Int32.Parse(palabras[2]);
            this.Palabras[1] = Int32.Parse(palabras[3]);
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

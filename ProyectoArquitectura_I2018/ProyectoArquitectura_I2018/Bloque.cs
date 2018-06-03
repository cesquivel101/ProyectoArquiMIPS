using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura_I2018
{
    public class Bloque
    {
        //No se que ponerle
        public List<int> Valores { get; set; }
        public string Estado { get; set; }
        public string Etiqueta { get; set; }

        public Bloque()
        {
            this.Valores = new List<int> { 0,0,0,0};
            this.Estado = null;
            this.Etiqueta = null;
        }

        public int this[int index]
        {
            get { return Valores[index]; }
            set { Valores[index] = value; }
        }

        public void imprimir()
        {
            Console.Write("Palabra: ");
            foreach (int _byte in Valores) {
                Console.Write(_byte.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}

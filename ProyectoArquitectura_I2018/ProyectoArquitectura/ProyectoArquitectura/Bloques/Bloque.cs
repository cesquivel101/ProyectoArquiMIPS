using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    public class Bloque
    {
        public List<int> Valores { get; set; }

        public Bloque()
        {
            this.Valores = new List<int> { 0};
        }

        public Bloque(string[] valores)
        {
            for(int i = 0; i < valores.Length;i++)
            {
                this.Valores[i] = Int32.Parse(valores[i]);
            }
        }

        public void imprimir()
        {
            Console.Write("Palabra: ");
            foreach (int _byte in Valores)
            {
                Console.Write(_byte.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}

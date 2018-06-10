using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    public class Bloque
    {
        
        public List<int> Valores { get; set; }

        public Bloque(int tamanioBloque, int valorInicializacion)
        {
            this.Valores = new List<int>();
            for (int i = 0; i < tamanioBloque; i++)
            {
                this.Valores.Add(valorInicializacion);
            }
        }

        public Bloque(string[] valores)
        {
            this.Valores = new List<int>();
            for(int i = 0; i < valores.Length;i++)
            {
                if (valores[i] != null)
                {
                    this.Valores.Add(Int32.Parse(valores[i]));
                }
                else
                {
                    i = valores.Length;
                }
            }
        }

        public void imprimir()
        {
            foreach (int _byte in Valores)
            {
                Console.Write(_byte.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}

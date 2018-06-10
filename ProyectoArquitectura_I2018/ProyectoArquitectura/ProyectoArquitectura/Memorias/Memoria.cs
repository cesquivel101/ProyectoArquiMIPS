using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProyectoArquitectura.Memorias
{
    public class Memoria
    {
        public List<Bloque> Datos { get; set; }
        public List<Bloque> Instrucciones { get; set; }

        public Memoria()
        {
            this.Datos = new List<Bloque>();
            this.Instrucciones = new List<Bloque>();
        }

        public void Imprimir()
        {
            Console.WriteLine("Datos");
            foreach (Bloque b in this.Datos)
            {
                b.imprimir();
            }
            Console.WriteLine("-------------");
            Console.WriteLine("Instrucciones");
            foreach (Bloque b in this.Instrucciones)
            {
                b.imprimir();
            }
        }



    }
}

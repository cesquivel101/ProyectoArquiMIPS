using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProyectoArquitectura.Memorias
{
    /// <summary>
    /// Clase que modela las memorias de la simulacion
    /// </summary>
    public class Memoria
    {
        public List<BloqueDatos> Datos { get; set; }
        public List<BloqueInstrucciones> Instrucciones { get; set; }

        public Memoria()
        {
            this.Datos = new List<BloqueDatos>();
            this.Instrucciones = new List<BloqueInstrucciones>();
        }

        public void Imprimir()
        {
            Console.WriteLine("Datos");
            foreach (BloqueDatos b in this.Datos)
            {
                b.imprimir();
            }
            Console.WriteLine("-------------");
            Console.WriteLine("Instrucciones");
            foreach (BloqueInstrucciones b in this.Instrucciones)
            {
                b.imprimir();
            }
        }

        public void impresionFinal()
        {
            Console.WriteLine("Memoria Datos");
            foreach (BloqueDatos b in this.Datos)
            {
                b.imprimir();
            }
        }

    }
}

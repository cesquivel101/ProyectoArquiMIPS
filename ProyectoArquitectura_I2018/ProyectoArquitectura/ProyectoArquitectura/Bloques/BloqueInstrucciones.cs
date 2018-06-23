using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    public class BloqueInstrucciones
    {
        public List<IR> Instrucciones { get; set; }

        public BloqueInstrucciones()
        {
            this.Instrucciones = new List<IR>();
        }

        public BloqueInstrucciones(List<IR> instrucciones)
        {
            this.Instrucciones = instrucciones;
        }


        public void imprimir()
        {
            foreach (IR instruccion in Instrucciones)
            {
                instruccion.imprimir();
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura_I2018
{
    public class Hilillo
    {
        public List<Instruccion> Instrucciones { get; set; }
        public string Estado { get; set; }

        public Hilillo() {
            this.Instrucciones = new List<Instruccion>();
            this.Estado = null;
        }

        public Hilillo(List<Instruccion> instrucciones, string estado)
        {
            this.Instrucciones = instrucciones;
            this.Estado = estado;
        }

    }
}

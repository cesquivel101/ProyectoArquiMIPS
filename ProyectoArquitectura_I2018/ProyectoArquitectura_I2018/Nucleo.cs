using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura_I2018
{
    public class Nucleo
    {
        public Cache Datos { get; set; }
        public Cache Instrucciones { get; set; }
        public Contexto Contexto { get; set; }
    }
}

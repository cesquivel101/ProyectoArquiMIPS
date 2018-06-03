using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura_I2018
{
    public class Contexto
    {
        public List<int> Registros { get; set; }
        public int PC { get; set; }
        public string Estado { get; set; }
        public int NumeroHilo { get; set; }
        public int ValorReloj { get; set; }
        public int QuantumRestante { get; set; }
    }
}

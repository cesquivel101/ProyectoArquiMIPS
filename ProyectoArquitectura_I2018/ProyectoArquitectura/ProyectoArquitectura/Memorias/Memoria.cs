using ProyectoArquitectura.Bloques;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Memorias
{
    public class Memoria
    {
        public List<Bloque> Datos { get; set; }
        public List<Bloque> Instrucciones { get; set; }
    }
}

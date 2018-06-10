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
            
        }



    }
}

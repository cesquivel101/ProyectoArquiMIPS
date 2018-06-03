using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura_I2018
{
    //No recuerdo si podiamos tener esto divido asi o habia que apegarnos a lo de la tarea. Me parecio escuchar decir algo a la profe.
    public class Memoria
    {
        public List<Bloque> datos { get; set; }
        public List<Bloque> instrucciones { get; set; }
    }
}

using ProyectoArquitectura.Caches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura
{
    public class Nucleo
    {
        public List<Cache> CacheDatos { get; set; }
        public List<Cache> CacheInstrucciones { get; set; }
    }
}

using ProyectoArquitectura.Caches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura
{
    public class Nucleo
    {
        public Cache CacheDatos { get; set; }
        public Cache CacheInstrucciones { get; set; }
        //Como maximo hay 2
        public List<InformacionDeEjecucion> InfoEjecucion{ get; set; }

        public Nucleo(int numInfoEjecucion)
        {
            this.CacheDatos = new Cache();
            this.CacheInstrucciones = new Cache();
            this.InfoEjecucion = new List<InformacionDeEjecucion>();
            for (int i = 0; i < numInfoEjecucion; i++)
            {
                this.InfoEjecucion.Add(new InformacionDeEjecucion());
            }
        }
    }
}

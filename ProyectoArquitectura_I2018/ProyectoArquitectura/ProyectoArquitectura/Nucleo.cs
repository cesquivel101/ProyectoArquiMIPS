using ProyectoArquitectura.Caches;
using ProyectoArquitectura.Helpers;
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
        //Como maximo hay 2
        public List<IR> RegistroInstruccion { get; set; }

        public Nucleo(int numInfoEjecucion, int numeroBloques)
        {
            this.CacheDatos = new Cache(numeroBloques, Constantes.Tipo_Cache_Datos);
            this.CacheInstrucciones = new Cache(numeroBloques, Constantes.Tipo_Cache_Instrucciones);
            this.InfoEjecucion = new List<InformacionDeEjecucion>();
            for (int i = 0; i < numInfoEjecucion; i++)
            {
                this.InfoEjecucion.Add(new InformacionDeEjecucion());
            }
            this.RegistroInstruccion = new List<IR>();
        }
    }
}

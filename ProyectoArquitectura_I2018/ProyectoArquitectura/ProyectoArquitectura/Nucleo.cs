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
        public InformacionDeEjecucion InfoEjecucion{ get; set; }
        public IR RegistroInstruccion { get; set; }
        public int PC { get; set; }
        public int Reloj { get; set; }
        public Nucleo()
        {
            this.CacheDatos = new Cache(Constantes.Tipo_Cache_Datos);
            this.CacheInstrucciones = new Cache(Constantes.Tipo_Cache_Instrucciones);
            this.InfoEjecucion = new InformacionDeEjecucion();
            this.RegistroInstruccion = new IR();
            this.Reloj = new int();
        }
    }
}

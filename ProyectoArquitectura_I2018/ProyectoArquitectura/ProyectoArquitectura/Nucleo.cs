using ProyectoArquitectura.Caches;
using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura
{
    public class Nucleo
    {
        public CacheDatos CacheDatos { get; set; }
        public CacheInstrucciones CacheInstrucciones { get; set; }
        //public InformacionDeEjecucion InfoEjecucion{ get; set; }
        public IR RegistroInstruccion { get; set; }
        public int PC { get; set; }
        public int Reloj { get; set; }
        public Nucleo()
        {
            this.CacheDatos = new CacheDatos();
            this.CacheInstrucciones = new CacheInstrucciones();
            //this.InfoEjecucion = new InformacionDeEjecucion();
            this.RegistroInstruccion = new IR();
            this.Reloj = new int();
        }

    }
}

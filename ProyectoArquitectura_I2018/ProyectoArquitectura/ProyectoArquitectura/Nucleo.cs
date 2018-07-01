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
        public List<int> Registros { get; set; }
        //public InformacionDeEjecucion InfoEjecucion{ get; set; }
        public IR RegistroInstruccion { get; set; }
        public int PC { get; set; }
        public int Reloj { get; set; }
        public int IDHililloEjecutandose { get; set; }
        public Nucleo()
        {
            this.CacheDatos = new CacheDatos();
            this.CacheInstrucciones = new CacheInstrucciones();
            this.Registros = new List<int>();
            for (int i = 0; i < Constantes.Cantidad_Registros; i++)
            {
                this.Registros.Add(0);
            }
            //this.InfoEjecucion = new InformacionDeEjecucion();
            this.RegistroInstruccion = new IR();
            this.Reloj = new int();
            this.IDHililloEjecutandose = -1;
        }

        public void imprimirRegistros()
        {
            for(int i = 0; i < Constantes.Cantidad_Registros;i++)
            {
                Console.Write("Registro " + i + ": " + this.Registros[i] + ";");
            }
        }

    }
}

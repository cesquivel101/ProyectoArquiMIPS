using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Caches
{
    /// <summary>
    /// Clase que simula una cache de datos
    /// </summary>
    public class CacheDatos
    {
        public List<BloqueCacheDatos> Bloques;
        //Tipo 0 es para cache de datos
        public CacheDatos()
        {
            this.Bloques = new List<BloqueCacheDatos>();
            for (int i = 0; i < Constantes.Numero_Bloques_Cache; i++)
            {
                this.Bloques.Add(new BloqueCacheDatos(i));
            }
        }

        public void impresionFinal()
        {
            Console.WriteLine("Cache Datos:");
            foreach (BloqueCacheDatos bcd in this.Bloques)
            {
                bcd.imprimir();
            }
        }
    }
}

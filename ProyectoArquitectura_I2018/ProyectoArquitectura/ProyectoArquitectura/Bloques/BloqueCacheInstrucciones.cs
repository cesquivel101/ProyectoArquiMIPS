using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    /// <summary>
    /// Clase que simula un bloque de cache de instrucciones
    /// </summary>
    public class BloqueCacheInstrucciones
    {
        private const int Valor_Inicializacion_Cache = 0;
        public BloqueInstrucciones Bloque { get; set; }
        /// <summary>
        /// Invalido, Compartido o Modificado (I,C o M)
        /// </summary>
        public string Estado { get; set; }
        /// <summary>
        /// Numero del bloque en la posicion de la cache
        /// </summary>
        public int Etiqueta { get; set; }

        /// <summary>
        /// Bloqueado o Libre (B o L)
        /// </summary>
        public string Estado_Posicion { get; set; }

        public BloqueCacheInstrucciones(int etiqueta)
        {
            this.Estado = Constantes.Estado_Invalido;
            this.Etiqueta = etiqueta;
            this.Bloque = new BloqueInstrucciones();
        }

        public void imprimir()
        {
            Console.Write("Estado:" + this.Estado+";");
            Console.Write("Etiqueta:" + this.Etiqueta);
            Console.WriteLine();
            if (this.Bloque != null)
            {
                Bloque.imprimir();
            }
        }
    }
}

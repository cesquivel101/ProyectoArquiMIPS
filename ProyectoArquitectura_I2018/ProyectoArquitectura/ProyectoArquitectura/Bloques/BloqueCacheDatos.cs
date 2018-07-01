using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    /// <summary>
    /// Clase que simula un bloque de cache de datos
    /// </summary>
    public class BloqueCacheDatos
    {
        public BloqueDatos Bloque { get; set; }
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

        public BloqueCacheDatos(int etiqueta)
        {

            this.Estado = Constantes.Estado_Invalido;
            this.Etiqueta = etiqueta;
            this.Estado_Posicion = Constantes.Estado_PosicionCache_Libre;
        }

        public void imprimir()
        {
            this.Bloque.imprimir();
        }

    }
}

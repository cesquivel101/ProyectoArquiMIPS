using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Helpers
{
    public static class Constantes
    {
        public const int Num_Valores_X_Palabra_Instruccion = 4;
        public const int Num_Palabras_X_Bloque = 4;
        public const int Posicion_Inicial_Memoria_instrucciones = 384;
        public const int Numero_Bloques_Memoria_Datos = 24;
        public const int Numero_Bloques_Memoria_Instrucciones = 40;
        public const int Numero_Hilos_Bloque_0 = 2;
        public const int Numero_Hilos_Bloque_1 = 1;
        public const int Cache_Datos_Tamanio_Bloque = 4;
        public const int Cache_Instrucciones_Tamanio_Bloque = 16;

        public const int Tipo_Cache_Datos = 0;
        public const int Tipo_Cache_Instrucciones = 1;

        public const int Numero_Bloques_Nucleo_0 = 8;
        public const int Numero_Bloques_Nucleo_1 = 4;

        //Codigos
        public const string Codigo_Fin = "63";

        //Estados Cache
        public const string Estado_Invalido = "I";
    }
}

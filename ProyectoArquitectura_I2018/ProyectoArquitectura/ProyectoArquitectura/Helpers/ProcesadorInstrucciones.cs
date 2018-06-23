using ProyectoArquitectura.Memorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Helpers
{
    public class ProcesadorInstrucciones
    {
        
        //Este metodo no procesa ni LW ni SW
        public static void procesarInstruccion(ref Nucleo nucleo)
        {
            nucleo.PC += Constantes.Byte;
            int co = nucleo.RegistroInstruccion.CO;
            switch (co)
            {
                case Codigos.CODIGO_DADDI:
                    nucleo.Registros[nucleo.RegistroInstruccion.Rf2_Rd] = nucleo.Registros[nucleo.RegistroInstruccion.Rf1] + nucleo.RegistroInstruccion.Rd_inm;
                    break;
                case Codigos.CODIGO_DADD:
                    nucleo.Registros[nucleo.RegistroInstruccion.Rd_inm] = nucleo.Registros[nucleo.RegistroInstruccion.Rf1] + nucleo.Registros[nucleo.RegistroInstruccion.Rf2_Rd];
                    break;
                case Codigos.CODIGO_DSUB:
                    nucleo.Registros[nucleo.RegistroInstruccion.Rd_inm] = nucleo.Registros[nucleo.RegistroInstruccion.Rf1] - nucleo.Registros[nucleo.RegistroInstruccion.Rf2_Rd];
                    break;
                case Codigos.CODIGO_DMUL:
                    nucleo.Registros[nucleo.RegistroInstruccion.Rd_inm] = nucleo.Registros[nucleo.RegistroInstruccion.Rf1] * nucleo.Registros[nucleo.RegistroInstruccion.Rf2_Rd];
                    break;
                case Codigos.CODIGO_DDIV:
                    nucleo.Registros[nucleo.RegistroInstruccion.Rd_inm] = nucleo.Registros[nucleo.RegistroInstruccion.Rf1] / nucleo.Registros[nucleo.RegistroInstruccion.Rf2_Rd];
                    break;
                case Codigos.CODIGO_BEQZ:
                    if (nucleo.Registros[nucleo.RegistroInstruccion.Rf1] == 0)
                    {
                        nucleo.PC += Constantes.Byte * nucleo.RegistroInstruccion.Rd_inm;
                    }
                    break;
                case Codigos.CODIGO_BNEZ:
                    if (nucleo.Registros[nucleo.RegistroInstruccion.Rf1] != 0)
                    {
                        nucleo.PC += Constantes.Byte * nucleo.RegistroInstruccion.Rd_inm;
                    }
                    break;
                case Codigos.CODIGO_JAL:
                    nucleo.PC += nucleo.RegistroInstruccion.Rd_inm;
                    break;
                case Codigos.CODIGO_JR:
                    nucleo.PC += nucleo.Registros[nucleo.RegistroInstruccion.Rf1];
                    break;
                case Codigos.CODIGO_FIN:
                    //Invalido el nucleo.PC 
                    //TODO pop
                    nucleo.PC = -1;
                    break;

            }
        }


        public void procesarLW(ref Nucleo nucleo, ref Nucleo otro, ref Bus bus,ref Memoria memoria )
        {
            IR insActual = nucleo.RegistroInstruccion;
            int posMemoria = insActual.Rf1 + insActual.Rd_inm;

            int bloqueMemoria = posMemoria / 4; //Poner 16 en constante
            int palabra = (posMemoria % 4) / Constantes.Numero_Bloques_Cache;
            int posicionEnCache = bloqueMemoria % Constantes.Numero_Bloques_Cache;

            while (nucleo.CacheDatos.Bloques[posicionEnCache].Estado_Posicion == Constantes.Estado_PosicionCache_Bloqueado)
            {
                //Ticks the reloj
            }

            //Verificar etiqueta
            //En caso de que SI este
            if (nucleo.CacheDatos.Bloques[posicionEnCache].Etiqueta == bloqueMemoria)
            {
                string estadoActualBloque = nucleo.CacheDatos.Bloques[posicionEnCache].Estado;

                //Hit
                if (estadoActualBloque != Constantes.Estado_Invalido)
                {

                    nucleo.Registros[insActual.Rf2_Rd] = nucleo.CacheDatos.Bloques[posicionEnCache].Bloque.Palabras[palabra];
                }
                //Miss
                else
                {
                    while (bus.Bloqueado)
                    {
                        //ticks de reloj
                    }
                    bus.Bloqueado = true;
                    nucleo.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Bloqueado;

                    //Verificar si esta en la otra cache
                    while (otro.CacheDatos.Bloques[posicionEnCache].Estado_Posicion == Constantes.Estado_PosicionCache_Bloqueado)
                    {
                        //tics de reloj
                    }
                    otro.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Bloqueado;


                    if (otro.CacheDatos.Bloques[posicionEnCache].Etiqueta == bloqueMemoria)
                    {
                        //Se copia a memoria, Se pone en compartido, se copia a mi cache
                        memoria.Datos[bloqueMemoria] = otro.CacheDatos.Bloques[posicionEnCache].Bloque;
                        otro.CacheDatos.Bloques[posicionEnCache].Estado = Constantes.Estado_Compartido;
                        nucleo.CacheDatos.Bloques[posicionEnCache].Bloque = otro.CacheDatos.Bloques[posicionEnCache].Bloque;
                        nucleo.CacheDatos.Bloques[posicionEnCache].Estado = Constantes.Estado_Compartido;

                        //esperar 40 ciclos de reloj
                    }

                    otro.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Libre;
                    nucleo.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Libre;
                    bus.Bloqueado = false;
                }
            }
            else
            {
                while (bus.Bloqueado)
                {
                    //ticks de reloj
                }
                bus.Bloqueado = true;
                nucleo.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Bloqueado;

                //Si mi bloque en posicionCache esta en m, deberiamos escribir primero a memoria

                //Verificar si esta en la otra cache
                while (otro.CacheDatos.Bloques[posicionEnCache].Estado_Posicion == Constantes.Estado_PosicionCache_Bloqueado)
                {
                    //tics de reloj
                }
                otro.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Bloqueado;

                ///

                if (otro.CacheDatos.Bloques[posicionEnCache].Etiqueta == bloqueMemoria)
                {
                    //if()
                }


                ///
                otro.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Libre;
                nucleo.CacheDatos.Bloques[posicionEnCache].Estado_Posicion = Constantes.Estado_PosicionCache_Libre;
                bus.Bloqueado = false;

            }




        }

        public void procesarSW()
        {
            //Cada vez que reservo y no logro agarrar el bus
        }
    }
}

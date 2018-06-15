using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Helpers
{
    public class ProcesadorInstrucciones
    {
        
        //Este metodo no procesa ni LW ni SW
        public static void procesarInstruccion(List<int> ir,ref List<int> registros,ref int pc)
        {
            pc += Constantes.Byte;
            int co = ir[0];
            switch (co)
            {
                case Codigos.CODIGO_DADDI:
                    registros[ir[3]] = registros[ir[1]] + ir[3];
                    break;
                case Codigos.CODIGO_DADD:
                    registros[ir[3]] = registros[ir[1]] + registros[ir[2]];
                    break;
                case Codigos.CODIGO_DSUB:
                    registros[ir[3]] = registros[ir[1]] - registros[ir[2]];
                    break;
                case Codigos.CODIGO_DMUL:
                    registros[ir[3]] = registros[ir[1]] * registros[ir[2]];
                    break;
                case Codigos.CODIGO_DDIV:
                    registros[ir[3]] = registros[ir[1]] / registros[ir[2]];
                    break;
                case Codigos.CODIGO_BEQZ:
                    if (registros[ir[1]] == 0)
                    {
                        pc += Constantes.Byte * ir[3];
                    }
                    break;
                case Codigos.CODIGO_BNEZ:
                    if (registros[ir[1]] != 0)
                    {
                        pc += Constantes.Byte * ir[3];
                    }
                    break;
                case Codigos.CODIGO_JAL:
                    pc += ir[3];
                    break;
                case Codigos.CODIGO_JR:
                    pc += registros[ir[1]];
                    break;
                case Codigos.CODIGO_FIN:
                    //Invalido el pc 
                    pc = -1;
                    break;

            }
        }

        public void procesarLW(ref Nucleo nucleo, ref Bus bus)
        {

        }

        public void procesarSW()
        {
            //Cada vez que reservo y no logro agarrar el bus
        }
    }
}

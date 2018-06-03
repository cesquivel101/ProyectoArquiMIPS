using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura_I2018
{
    public class Instruccion
    {
        public int CO { get; set; }
        public int Rf1 { get; set; }
        public int Rf2_Rd { get; set; }
        public int Rd_Inm { get; set; }

        public Instruccion()
        {
            this.CO = -1;
            this.Rf1 = -1;
            this.Rf2_Rd = -1;
            this.Rd_Inm = -1;
        }

        public Instruccion(int co, int rf1, int rf2_rd, int rd_Inm)
        {
            this.CO = co;
            this.Rf1 = rf1;
            this.Rf2_Rd = rf2_rd;
            this.Rd_Inm = rd_Inm;
        }

        public void imprimir()
        {
            Console.WriteLine("CO: " + this.CO);
            Console.WriteLine("RF1: " + this.Rf1);
            Console.WriteLine("RF2_RD: " + this.Rf2_Rd);
            Console.WriteLine("RD_INM: " + this.Rd_Inm);
            Console.WriteLine();
            
        }
    }
}

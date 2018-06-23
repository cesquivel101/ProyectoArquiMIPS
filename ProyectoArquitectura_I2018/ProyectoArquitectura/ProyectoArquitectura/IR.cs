using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura
{
    public class IR
    {
        public int CO { get; set; }
        public int Rf1 { get; set; }
        public int Rf2_Rd { get; set; }
        public int Rd_inm { get; set; }

        public IR(int co, int rf1, int rf2_rd,int rd_inm)
        {
            this.CO = co;
            this.Rf1 = rf1;
            this.Rf2_Rd = rf2_rd;
            this.Rd_inm = rd_inm;
        }

        public IR() { }

        public void imprimir()
        {
            Console.Write(this.CO + " ");
            Console.Write(this.Rf1 + " ");
            Console.Write(this.Rf2_Rd + " ");
            Console.Write(this.Rd_inm + " ");
        }

    }
}

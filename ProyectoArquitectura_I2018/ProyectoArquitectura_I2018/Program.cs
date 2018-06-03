using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoArquitectura_I2018
{
    class Program
    {
        static void Main(string[] args)
        {
            //string currentDir = Directory.GetCurrentDirectory();
            //string previousDir = currentDir.Substring(0, currentDir.LastIndexOf('\\'));
            //DirectoryInfo di = new DirectoryInfo(previousDir);
            //foreach (var file in di.GetFiles("*.txt"))
            //{
            //    List<Instruccion> instrucciones = LectorHilillos.leerHilillo(file.FullName);
            //    printHilillo(instrucciones);
            //}
            //Console.ReadKey();

        }
        static void printHilillo(List<Instruccion> instrucciones)
        {
            foreach (Instruccion instruccion in instrucciones)
            {
                instruccion.imprimir();
            }
            Console.Write("-------------------\n");
        }
    }
}
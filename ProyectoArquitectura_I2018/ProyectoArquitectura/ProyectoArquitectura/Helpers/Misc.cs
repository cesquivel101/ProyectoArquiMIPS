using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Helpers
{
    public static class Misc
    {
        public static List<int> TodosLosIndices(string aBuscar, List<string> listaObjetivo)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < listaObjetivo.Count; i++)
            {
                if (listaObjetivo[i].Equals(aBuscar))
                {
                    indices.Add(i);
                }
            }
            return indices;
        }
    }
}

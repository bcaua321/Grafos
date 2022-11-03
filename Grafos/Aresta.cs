using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Aresta
    {
        public int VerticeUm { get; set; }
        public int VerticeDois { get; set; }
        public int Peso { get; set; }

        public Aresta(int verticeUm, int verticeDois)
        {
            VerticeUm = verticeUm;
            VerticeDois = verticeDois;
        }

        public Aresta(int verticeUm, int verticeDois, int peso)
        {
            VerticeUm = verticeUm;
            VerticeDois = verticeDois;
            Peso = peso;
        }
    }
}

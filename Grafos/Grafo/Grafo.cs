using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Grafo
    {
        public Dictionary<int, List<int>> ListaAdj { get; set; } // Lista de adj por dictionary
        public List<int> Vertices { get; } // Lista de adj por Vertices
        public List<int>[] ListaAdjByList;
        public int NumeroVertices { get; set; }
        public Grafo(int numeroVertices)
        {
            this.NumeroVertices = numeroVertices;
            ListaAdjByList = new List<int>[numeroVertices];
            for (int i = 0; i < numeroVertices; i++)
                ListaAdjByList[i] = new List<int>();
        }
        public Grafo()
        {
            this.ListaAdj = new Dictionary<int, List<int>>(); 
        }


        // Adicionar uma aresta a lista de adjcencia com lista
        public void AddAresta(int u, int v) { ListaAdjByList[u].Add(v); }

        // Adicionar uma aresta a lista de adjcencia com dicionário. Somente BFS E DFS
        public void SetAdja(int v1, int v2)
        {
            List<int> adjaExistente = new List<int>();
            List<int> adja = new List<int>();

            bool listaExiste = ListaAdj.ContainsKey(v1);

            // Caso tenha uma lista de adjacencia do vertice v1, então irá guardar os valores existentes mais o novo
            if (listaExiste)
            {
                ListaAdj.TryGetValue(v1, out adjaExistente); 
                adja.AddRange(adjaExistente);
                adja.Add(v2);

                ListaAdj[v1] = adja;
                return;
            }

            // Caso não tenha uma lista de adjacencia do vertice v1
            adja.Add(v2);
            ListaAdj.Add(v1, adja);
        }

        // Verifica se existe os vertices v1 e v2 nos vertices definidos pelo usuário
        private bool Exist(int v1, int v2)
        {
            bool estaContido = Vertices.Where(x => x == v1 || x == v2).Count() > 2;
            return estaContido;
        }

        public void PrintAdj()
        {
            foreach (KeyValuePair<int, List<int>> item in ListaAdj)
            {
                Console.Write($"Vertice(s) adjacente(s) a {item.Key}: ");

                foreach(int v in item.Value)
                {
                    Console.Write($" {v}");
                }

                Console.WriteLine();
            }
        }
    }
}

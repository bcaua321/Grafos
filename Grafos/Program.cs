using Grafos.BFS;
using Grafos.DFS;
using Grafos.Dijkstra;
using Grafos.Kahn;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Grafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Grafo gf = new Grafo();

            gf.SetAdja(0, 1);
            gf.SetAdja(0, 5);
            gf.SetAdja(1, 6);
            gf.SetAdja(1, 2);
            gf.SetAdja(6, 3);
            gf.SetAdja(6, 4);
            gf.SetAdja(4, 5);
            gf.PrintAdj();

            BuscaDfs dfs = new BuscaDfs(gf.ListaAdj);
            BuscaBfs bfs = new BuscaBfs(gf.ListaAdj);

            Console.WriteLine();
            Console.WriteLine("------DFS------");
            dfs.Executar(0);
            dfs.PrintVisitados();

            Console.WriteLine();
            Console.Write("------BFS------");
            bfs.Executar(0);
            bfs.PrintVisitados();
            */

            /*
             Kahn AlGoritm *****

            Grafo g = new Grafo(5);
            g.AddAresta(0, 1);
            g.AddAresta(1, 2);
            g.AddAresta(2, 3);
            g.AddAresta(3, 4);

            Console.WriteLine("Ordem topologico pelo algoritmo de Kahn: ");
            KahnAlg kahn = new KahnAlg(g.ListaAdjByList, g.NumeroVertices);
            kahn.OrdenacaoTopologica();
            */

            /* Dijkstra */
            /* Para grafo não dirigido, é bom repetir a aresta mas com os valores dos vertices trocados*/

            List<Aresta> arestas = new List<Aresta>
            {
                new Aresta(0, 1, 1),
                new Aresta(0, 2, 3),
                new Aresta(1, 2, 1),
                new Aresta(2, 3, 1),
                new Aresta(3, 4, 1),
                new Aresta(4, 5, 1),
                new Aresta(5, 0, 6)
            };


            List<Vertices> vertices = new List<Vertices>
            {
                new Vertices(0),
                new Vertices(1),
                new Vertices(2),
                new Vertices(3),
                new Vertices(4),
                new Vertices(5)
            };

            DijkstraAlg dijkstra = new DijkstraAlg(arestas, vertices, 0);

            var result = dijkstra.VerticesAdjacentes(1);

            dijkstra.Executar();


            dijkstra.printPath();
        }
    }
}

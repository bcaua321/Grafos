using Grafos.BFS;
using Grafos.DFS;
using Grafos.Dijkstra;
using Grafos.Kahn;
using System;
using System.Collections.Generic;

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

            List<Aresta> arestas = new List<Aresta>
            {
                new Aresta(1, 2, 7),
                new Aresta(1, 3, 9),
                new Aresta(1, 6, 14),
                new Aresta(2, 4, 15),
                new Aresta(2, 3, 10),
                new Aresta(3, 4, 11),
                new Aresta(3, 6, 2),
                new Aresta(6, 5, 9),
                new Aresta(4, 5, 6)
            };


            List<Vertices> vertices = new List<Vertices>
            {
                new Vertices(1),
                new Vertices(2),
                new Vertices(3),
                new Vertices(4),
                new Vertices(5),
                new Vertices(6)
            };

            DijkstraAlg dijkstra = new DijkstraAlg(arestas, vertices, 1);

            var result = dijkstra.VerticesAdjacentes(1);

            dijkstra.Executar();
            dijkstra.printPath();
        }
    }
}

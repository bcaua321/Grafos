using Grafos.BFS;
using Grafos.DFS;
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

            Grafo g = new Grafo(6);
            g.AddAresta(5, 2);
            g.AddAresta(5, 0);
            g.AddAresta(4, 0);
            g.AddAresta(4, 1);
            g.AddAresta(2, 3);
            g.AddAresta(3, 1);

            Console.WriteLine("Ordem topologico pelo algoritmo de Kahn: ");
            KahnAlg kahn = new KahnAlg(g.ListaAdjByList, g.NumeroVertices);
            kahn.OrdenacaoTopologica();
        }
    }
}

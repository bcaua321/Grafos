using Grafos.BFS;
using Grafos.DFS;
using System;
using System.Collections.Generic;

namespace Grafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}

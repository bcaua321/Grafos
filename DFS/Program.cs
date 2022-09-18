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
            Grafo gf = new Grafo(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            
            gf.SetAdja(1, 2);

            gf.SetAdja(1, 7);
            gf.SetAdja(1, 8);

            gf.SetAdja(2, 6);
            gf.SetAdja(2, 3);

            gf.SetAdja(3, 5);
            gf.SetAdja(3, 4);

            gf.SetAdja(8, 12);
            gf.SetAdja(8, 9);

            gf.SetAdja(9, 11);
            gf.SetAdja(9, 10);
            
            /*
            gf.SetAdja(0, 1);
            gf.SetAdja(1, 2);
            gf.SetAdja(1, 3);
            gf.SetAdja(2, 4);
            gf.SetAdja(4, 1);
            gf.SetAdja(3, 4);
            gf.SetAdja(3, 0);*/

            gf.PrintAdj();

            BuscaDfs dfs = new BuscaDfs(gf.ListaAdj, gf.Vertices);
            BuscaBfs bfs = new BuscaBfs(gf.ListaAdj, gf.Vertices);

            bfs.Executar(1);
            bfs.PrintVisitados();
        }
    }
}

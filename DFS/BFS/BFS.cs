﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class BFS
    {
        private IReadOnlyDictionary<int, List<int>> ListaAdj { get; }
        private IReadOnlyList<int> Vertices { get; }
        private List<int> Visitados { get; }
        private Queue<int> Fila { get; }

        public BFS(IReadOnlyDictionary<int, List<int>> listaAdj, IReadOnlyList<int> vertices)
        {
            ListaAdj = listaAdj;
            Vertices = vertices;
            Visitados = new List<int>();
            Fila = new Queue<int>();
        }

        public void Executar(int v)
        {
            List<int> valores = new List<int>();
            ListaAdj.TryGetValue(v, out valores);

            if (valores == null)
            {
                Fila.Dequeue();

                if (Fila.Count == 0)
                    return;

                Executar(Fila.Peek());
                return;
            }

            if(!Fila.Contains(v))
            {
                Fila.Enqueue(v);
                Visitados.Add(v);
            }

            foreach (int i in valores)
            {
                if (Visitados.Contains(i))
                    continue;

                Console.Write($"{i} ");
                Visitados.Add(i);
                Fila.Enqueue(i);
            }

            Console.WriteLine();
            Fila.Dequeue();

            if (Fila.Count == 0 && Visitados.Count > 0)
                return;

            Executar(Fila.Peek());
        }

        public void PrintVisitados()
        {
            Console.Write("Visitados: ");
            foreach (var item in Visitados.OrderBy(x => x))
            {
                Console.Write($"{item} ");
            }
        }
    }
}
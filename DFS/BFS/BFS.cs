using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.BFS
{
    public class BuscaBfs
    {
        private IReadOnlyDictionary<int, List<int>> ListaAdj { get; }
        private List<int> Visitados { get; }
        private Queue<int> Fila { get; }

        public BuscaBfs(IReadOnlyDictionary<int, List<int>> listaAdj)
        {
            ListaAdj = listaAdj;
            Visitados = new List<int>();
            Fila = new Queue<int>();
        }

        public void Executar(int v)
        {
            // Se for a primeira vez que o vértice será adicionado na Fila
            if (!Fila.Contains(v))
            {
                Console.WriteLine($"\nInício: {v}");
                Fila.Enqueue(v);
                Visitados.Add(v);
            }

            List<int> valoresAdj = new List<int>();

            // Se o vértice não tiver vértices adjacentes
            if (!ListaAdj.TryGetValue(v, out valoresAdj))
            {
                Fila.Dequeue();
                if (Fila.Count == 0)
                    return;

                Executar(Fila.Peek());
                return;
            }

            foreach (int i in valoresAdj)
            {
                if (Visitados.Contains(i))
                    continue;

                Console.Write($"{i} ");
                Visitados.Add(i);
                Fila.Enqueue(i);
            }
            Console.WriteLine();

            Fila.Dequeue();
            if (Fila.Count == 0)
                return;

            Executar(Fila.Peek());
        }

        public void PrintVisitados()
        {
            Console.Write("Ordem Visitados: ");
            foreach (var item in Visitados)
            {
                Console.Write($"{item} ");
            }
        }
    }
}

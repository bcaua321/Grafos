using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.BFS
{
    public class BuscaBfs
    {
        private IReadOnlyDictionary<int, List<int>> ListaAdj { get; } // para guardar a lista de adjacencia
        private List<int> Visitados { get; } // para guardar os vértices visitados
        private Queue<int> Fila { get; } // para ter o controle dos vértices visitados

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
                Fila.Dequeue(); // retira o vértice da ordem 
                if (Fila.Count == 0)
                    return;

                Executar(Fila.Peek()); // pega o próximo vértice
                return;
            }

            // Percorre todos os vértices adjacentes do vértice e adiciona na fila
            foreach (int item in valoresAdj) 
            {
                if (Visitados.Contains(item))
                    continue;

                Console.Write($"{item} ");
                Visitados.Add(item);
                Fila.Enqueue(item);
            }
            Console.WriteLine();

            Fila.Dequeue(); // Retira o vértice atual da fila 
            if (Fila.Count == 0)
                return;

            Executar(Fila.Peek()); // Pega o próximo vértice da fila
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.DFS
{
    public class BuscaDfs
    {
        private IReadOnlyDictionary<int, List<int>> ListaAdj { get; } // para guardar a lista de adjacencia
        private List<int> Visitados { get; } // para guardar os vértices visitados

        public BuscaDfs(Dictionary<int, List<int>> matrizAdj)
        {
            ListaAdj = matrizAdj;
            Visitados = new List<int>();
        }

        public void Executar(int vertice)
        {
            // verifica se os vértices visitados possui o vértice
            if (Visitados.Contains(vertice))
                return;

            // Se não tiver um indice correspondente na lista de adj,
            // adiciona nos vértices visitados, pois pode ser um vertice que não contém
            // outro vértice adjacente
            if (!ListaAdj.ContainsKey(vertice))
            {
                Visitados.Add(vertice);
                return;
            }
                
            // para armazenar os vértices adjacentes
            List<int> aux = new List<int>();

            Visitados.Add(vertice); 
            ListaAdj.TryGetValue(vertice, out aux); // verifica os vértices adjacentes do vértice 
            foreach (var item in aux)
            {
                Console.WriteLine($"{vertice} -> {item}");
                if (Visitados.Contains(item))
                    continue;

                Executar(item); // chama novamente a função e repete o processo
            }
        }

        public void PrintVisitados()
        {
            Console.Write("Ordem Visitados: ");
            foreach(var item in Visitados)
            {
                Console.Write($"{item} ");
            }
        }
     }
}

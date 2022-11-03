using System.Collections.Generic;
using System.Linq;
using System;

namespace Grafos.Dijkstra
{
    public class DijkstraAlg
    {
        private IList<Aresta> Arestas { get; } // Arestas com Pesos
        private IList<VerticeValorado> Result { get; } // Resultado depois de percorrer todos os vertices
        private IList<Vertices> Vertices { get; } // Para ter o controle dos vertices não visitados
        public DijkstraAlg(List<Aresta> arestas, List<Vertices> vertices, int verticeInicial)
        {
            Arestas = arestas;
            Vertices = vertices;
            Result = new List<VerticeValorado>();
            Preencher(verticeInicial);
        }

        public void Executar()
        {
            // Se não tive vertices não visitados, irá parar o algoritmo
            if (Vertices.Count == 0)
                return;

            var min = TakeMin(); // Irá pegar o menor valor que esteja nos vertices não visitados

            var verticesAdj = VerticesAdjacentes(min.Vertice); // Depois irá pegar todos os vértices adjacentes ao vertice escolhido

            foreach(var item in verticesAdj)
            {
                var soma = min.Valor + item.Peso;
                if(soma < PegarValorVertice(item.VerticeDois)) 
                {
                   AtualizarValores(item.VerticeDois, item.VerticeUm, soma);   
                }
            }

            Executar();
        }

        public VerticeValorado TakeMin()
        {
            var result = Result
            .FirstOrDefault(x => x.Valor < int.MaxValue &&
            Vertices.Any(v => v.Vertice == x.Vertice)); // Pega o primeiro valor menor que o simbolico e que esteja nos vertices não visitados
            var vertice = Vertices.Where(x => x.Vertice == result.Vertice).FirstOrDefault(); // remove do vertices não visitados

            Vertices.Remove(vertice);

            return result;
        }

        public List<Aresta> VerticesAdjacentes(int verticeUm)
        {
            return Arestas.Where(x => x.VerticeUm == verticeUm).ToList();
        }

        // Retorna o valor atribuido ao vertice
        public int PegarValorVertice(int n)
        {
            var result = Result.FirstOrDefault(x => x.Vertice == n).Valor;
            return result;
        }

        public void AtualizarValores(int vertice, int prev, int valor)
        {
            var result = Result.FirstOrDefault(x => x.Vertice == vertice);

            result.Valor = valor;
            result.Prev = prev;
        }

        // Seta os valores após a instância da classe
        private void Preencher(int verticeInicial)
        {
            foreach (var item in Vertices)
            {
                VerticeValorado vertice = new VerticeValorado
                {
                    Vertice = item.Vertice,
                    Valor = int.MaxValue,
                    Prev = null
                };

                if (item.Vertice == verticeInicial)
                {
                    vertice.Valor = 0;
                }

                Result.Add(vertice);
            }
        }

        // Irá fazer o print do caminho com os valores
        public void printPath()
        {
            foreach(var item in Result.OrderBy(x => x.Prev))
            {
                if (item.Prev == null)
                {
                    Console.WriteLine($"inicio => {item.Vertice}: {item.Valor}");
                    continue;
                }

                Console.WriteLine($"{item.Prev} => {item.Vertice}: {item.Valor}");
            }
        }
    }
}

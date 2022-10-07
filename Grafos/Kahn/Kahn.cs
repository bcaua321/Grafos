using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Kahn
{
    public class KahnAlg
    {
        private List<int>[] ListaAdjByList;
        private int NumeroVertices;

        public KahnAlg(List<int>[] listaAdjByList, int numeroVertices)
        {
            ListaAdjByList = listaAdjByList;
            NumeroVertices = numeroVertices;
        }
        public void OrdenacaoTopologica()
        {

            // Cria um array para armazenar os graus dos vertices. Obs: automaticamente inicializa para 0 os valores
            int[] grauVertices = new int[NumeroVertices];

            // Irá percorrer a lista de adjacencia para preencher os graus do vértices
            for (int u = 0; u < NumeroVertices; u++)
            {
                foreach (int vertice in ListaAdjByList[u]) grauVertices[vertice]++;
            }

            // Irá criar uma pilha para armazenar os vértices fontes
            Queue<int> pilha = new Queue<int>();
            for (int i = 0; i < NumeroVertices; i++)
                if (grauVertices[i] == 0)
                    pilha.Enqueue(i);

            // para contar a ordem dos vértices
            int contador = 0;

            // Irá guardar a ordem 
            List<int> ordem= new List<int>();

            // Irá fazer o loop enquanto tiver vértices fontes
            while (pilha.Count > 0)
            {
                // extrai o vértice fonte e adiciona na lista 
                int u = pilha.Dequeue();
                ordem.Add(u);

                // Iteragem em todos os vértices adjacentes e logo depois verifica se ele
                // se tornou vértice fonte, para assim adicionar na pilha

                foreach (int vertice in ListaAdjByList[u])
                {
                    if (--grauVertices[vertice] == 0)
                        pilha.Enqueue(vertice);
                }

                contador++;
            }

            // se o contador for diferente do número de vértices, quer dizer que há um ciclo
            if (contador != NumeroVertices)
            {
                Console.WriteLine("Existe um ciclo");
                return;
            }

            // Senao, irá printar a ordem
            for (int i = 0; i < ordem.Count; i++)
                Console.Write(ordem[i] + " ");
            Console.WriteLine();
        }
    }
}

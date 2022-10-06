using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.DFS
{
    public class BuscaDfs
    {
        private IReadOnlyDictionary<int, List<int>> ListaAdj { get; }
        private List<int> Visitados { get; }

        public BuscaDfs(Dictionary<int, List<int>> matrizAdj)
        {
            ListaAdj = matrizAdj;
            Visitados = new List<int>();
        }

        public void Executar(int valorInicial)
        {

            if (Visitados.Contains(valorInicial))
                return;

            if (!ListaAdj.ContainsKey(valorInicial))
            {
                Visitados.Add(valorInicial);
                return;
            }
                

            List<int> aux = new List<int>();

            Visitados.Add(valorInicial);
            ListaAdj.TryGetValue(valorInicial, out aux);

            foreach(var item in aux)
            {
                Console.WriteLine($"{valorInicial} -> {item}");
                if (Visitados.Contains(item))
                    continue;

                Executar(item);
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

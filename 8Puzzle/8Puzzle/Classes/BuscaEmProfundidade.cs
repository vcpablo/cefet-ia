using System;
using System.Collections.Generic;

namespace _8Puzzle.Classes
{
    public class BuscaEmProfundidade
    {
        public Stack<No> Pilha { get; set; }
        private No Resposta { get; set; }
        public int Iteracoes { get; set; }

        public BuscaEmProfundidade(No no)
        {
            Resposta = new No(1,2,3,4,5,6,7,8,0);

            Console.WriteLine("Resposta");
            Resposta.Print();

            Pilha = new Stack<No>();
            Pilha.Push(no);
        }

        private bool FoiAnalisado(No no)
        {
            No analisando = no;

            no = no.Pai;
            while (no != null)
            {
                if (analisando.Equals(no)) return true;
                no = no.Pai;
            }

            return false;
        }

        public void Iniciar()
        {
            int time = 1;

            while (Pilha.Count > 0)
            {
                if (time > Iteracoes) break;

                Console.Clear();
                Console.WriteLine("Iteração    : " + time);

                No no = Pilha.Pop();

                if (!no.Equals(Resposta))
                {
                    no.GerarFilhos();

                    foreach (No filho in no.Filhos)
                    {
                        if (!FoiAnalisado(filho))
                        {
                            Pilha.Push(filho);
                        }
                    }

                    time++;
                }
                else
                {
                    while (no != null)
                    {
                        no.Print();
                        no = no.Pai;
                    }

                    Console.WriteLine("Custo da solução: " + time);

                    return;
                }
            }

            Console.WriteLine("Solução não encontrada");
        }
    }
}

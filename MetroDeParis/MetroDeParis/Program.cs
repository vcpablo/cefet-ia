using MetroDeParis.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroDeParis
{
    class Program
    {
        private static Tabela tabela;
        private static Mapa mapa;

        private static No partida;
        private static No chegada;

        private static List<No> possibilidades;
        private static List<No> caminho;

        static void Main(string[] args)
        {
            possibilidades = new List<No>();
            caminho = new List<No>();
            mapa = new Mapa();

            byte origem = GetEstacao(true);
            byte destino = GetEstacao(false);

            partida = mapa.GetEstacao(origem);
            chegada = mapa.GetEstacao(destino);

            tabela = new Tabela(chegada);

            IniciarBusca(partida);

            Console.WriteLine("Melhor caminho de {0} até {1}", origem, destino);

            ImprimirCaminho();

            Console.ReadKey();
        }

        public static void IniciarBusca(No atual)
        {
            foreach (No no in atual.Adjacencias)
            {
                if (caminho.Contains(no)) continue;

                if (no.Equals(chegada))
                {
                    no.Pai = atual;
                    no.G = tabela.CalcularG(no);

                    caminho.Add(atual);
                    caminho.Add(no);
                    return;
                }

                if (no.Adjacencias.All(adj => adj.Equals(atual))) continue;

                if (!possibilidades.Contains(no))
                {
                    no.Pai = atual;
                    no.G = tabela.CalcularG(no);
                    no.H = tabela.CalcularH(no);

                    possibilidades.Add(no);
                }
                else
                {
                    int gTeste = atual.G + tabela.CalcularDistancia(atual, no);

                    if (gTeste < no.G)
                    {
                        no.Pai = atual;
                        no.G = gTeste;
                    }
                }
            }

            possibilidades.Remove(atual);
            No selecionado = Selecionar();

            caminho.Add(atual);
            IniciarBusca(selecionado);
        }

        public static No Selecionar()
        {
            No melhorCaminho = possibilidades.First();

            foreach (No no in possibilidades)
            {
                if (no.F() < melhorCaminho.F())
                {
                    melhorCaminho = no;
                }
            }

            return melhorCaminho;
        }

        private static void ImprimirCaminho()
        {
            int distancia = 0;

            foreach (No no in caminho)
            {
                distancia += no.G;
                Console.Write(no.Numero + " ");
            }

            Console.WriteLine("\nDistância: " + distancia + "km");

            double horas = (distancia / 30.0) * 60 + ((caminho.Count - 1) * 4.0);


            Console.WriteLine("Tempo de viagem: {0} minutos", horas);
        }

        public static byte GetEstacao(bool origem)
        {
            byte estacao = 0;
            bool valida = false;

            while (!valida)
            {
                Console.WriteLine("Informe o número da estação de {0} (1-14):", origem ? "origem" : "destino");

                valida = Byte.TryParse(Console.ReadLine(), out estacao);

                if (estacao < 1 || estacao > 14)
                {
                    valida = false;
                }

                if (!valida)
                {
                    Console.WriteLine("Estação inválida.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.Clear();

            return estacao;
        }
    }
}

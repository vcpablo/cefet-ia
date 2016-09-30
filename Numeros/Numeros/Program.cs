using Numeros.Classes;
using System;

namespace Numeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro();

            tabuleiro.AddPeca(5);
            tabuleiro.AddPeca(8);
            tabuleiro.AddPeca(1);
            tabuleiro.AddPeca(3);
            tabuleiro.AddPeca(7);
            tabuleiro.AddPeca(4);
            tabuleiro.AddPeca(6);
            tabuleiro.AddPeca(2);

            int movimento = 1;
            while (true)
            {
                Console.WriteLine("Digite 'exit' para sair" + Environment.NewLine);
                Console.WriteLine("Movimento " + movimento + Environment.NewLine);

                tabuleiro.Print();

                Console.Write("Mover peça: ");

                string input = Console.ReadLine();

                if (input == "exit")
                {
                    break;
                }

                byte valor;

                bool valid = byte.TryParse(input, out valor);

                if (!valid || valor < 1 || valor > 8)
                {
                    Console.WriteLine("Valor inválido");
                    Console.ReadKey();
                }
                else
                {
                    tabuleiro.Mover(valor);
                }

                Console.Clear();

                movimento++;
            }
            
        }
    }
}

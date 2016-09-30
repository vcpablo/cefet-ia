using _8Puzzle.Classes;
using System;
using System.Collections.Generic;

namespace _8Puzzle
{
    class Program
    {
        private static List<byte> bytes = new List<byte>(9);

        static void Main(string[] args)
        {
            while (bytes.Count < 9)
            {
                Console.Write("Iforme um valor de 0 a 8 para a peça {0}: ", bytes.Count + 1);
                bytes.Add(GetInput(Console.ReadLine()));
            }

            //(0,2,3,1,4,6,7,5,8);
            No no = new No(bytes.ToArray());
            no.Print();

            BuscaEmProfundidade busca = new BuscaEmProfundidade(no);
            busca.Iteracoes = GetIteracoes();
            busca.Iniciar();

            Console.ReadKey();
        }

        static int GetIteracoes()
        {
            int iteracoes;
            bool valido;

            do
            {
                Console.WriteLine("Número máximo de iterações: ");
                string input = Console.ReadLine();
                valido = int.TryParse(input, out iteracoes);
                if (valido) continue;
                Console.WriteLine("Valor inválido");
                Console.ReadKey();
                Console.Clear();
            } while (!valido);

            return iteracoes;
        }

        static byte GetInput(string input)
        {
            byte value;
            bool valid = Byte.TryParse(input, out value);
            if (value > 8 || bytes.Contains(value)) valid = false;

            if (valid)
            {
                Console.Clear();
                return value;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Valor inválido. Informe outro valor:");
                return GetInput(Console.ReadLine());
            }
        }
    }
}

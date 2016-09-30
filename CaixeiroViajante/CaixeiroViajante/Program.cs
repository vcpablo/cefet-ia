using CaixeiroViajante.Classes;
using System;
using System.Linq;

namespace CaixeiroViajante
{
    class Program
    {
        static void Main(string[] args)
        {
            HillClimbing hc = new HillClimbing();

            Console.Write("Informe a cidade de partida:");
            byte origem = GetInput(Console.ReadLine());

            Console.Write("Informe a cidade de destino:");
            byte destino = GetInput(Console.ReadLine());

            try
            {
                hc.Iniciar(origem, destino);

                string output = string.Join(" - ", hc.EspacoEstados.Select(c => c.Atual.ToString()).ToArray());

                Console.Write(output);
            }
            catch (Exception e)
            {
                string output = string.Join(" - ", hc.EspacoEstados.Select(c => c.Atual.ToString()).ToArray());

                Console.Write(output + "\n");

                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        static byte GetInput(string input)
        {
            byte value;
            bool valid = Byte.TryParse(input, out value);
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

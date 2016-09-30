using System;
using System.Collections.Generic;
using System.Linq;

namespace Numeros.Classes
{
    public class Tabuleiro
    {

        public List<Peca> Pecas { get; set; }

        public Tabuleiro()
        {
            Pecas = new List<Peca>(9);

            Peca peca = new Peca(0) {Linha = 0, Coluna = 0};

            Pecas.Add(peca);
        }

        public void AddPeca(byte valor)
        {
            if (Pecas.Count == 9) return;

            byte coluna = Convert.ToByte(Pecas.Count % 3);
            byte linha = Convert.ToByte(decimal.Truncate((decimal)Pecas.Count/3));
            
            Peca peca = new Peca(valor) {Linha = linha, Coluna = coluna};

            Pecas.Add(peca);
        }

        public void Print()
        {
            Console.WriteLine("---------");

            for (byte i = 0; i < 3; i++)
            {
                for (byte j = 0; j < 3; j++)
                {
                    byte valor = Pecas.Single(p => p.Linha == i && p.Coluna == j).Valor;
                    Console.Write(" {0} ", valor == 0 ? " " : valor.ToString());
                }

                Console.WriteLine();
            }

            Console.WriteLine("---------");
        }

        public void Mover(byte valor)
        {
            Peca pecaVazia = Pecas.Single(p => p.Valor == 0);
            Peca pecaMovida = Pecas.Single(p => p.Valor == valor);

            if (!pecaMovida.PodeTrocarCom(pecaVazia))
            {
                Console.WriteLine("Movimento inválido");
                Console.ReadKey();
                return;
            }

            byte linhaAnterior = pecaMovida.Linha;
            byte colunaAnterior = pecaMovida.Coluna;

            pecaMovida.Linha = pecaVazia.Linha;
            pecaMovida.Coluna = pecaVazia.Coluna;

            pecaVazia.Linha = linhaAnterior;
            pecaVazia.Coluna = colunaAnterior;
        }


    }
}

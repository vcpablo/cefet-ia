using System;
using System.Collections.Generic;
using System.Linq;

namespace _8Puzzle.Classes
{
    public class No
    {
        public No Pai { get; set; }
        public List<No> Filhos{ get; set; }
        public List<Peca> Pecas { get; set; }
        public int TempoEntrada { get; set; }
        public int TempoSaida { get; set; }
        public int Custo { get; set; }

        public No(params byte[] numeros)
        {
            Pecas = new List<Peca>();
            Filhos = new List<No>();

            foreach (byte numero in numeros)
            {
                AddPeca(numero);
            }
        }
        
        
        #region Private methods

        private void AddPeca(byte numero)
        {
            Peca peca = new Peca(numero);
            peca.Linha = Convert.ToByte(decimal.Truncate(Pecas.Count/3));
            peca.Coluna = Convert.ToByte(Pecas.Count%3);

            Pecas.Add(peca);
        }

        private void MoverPeca(byte numero)
        {
            Peca pecaVazia = Pecas.Single(p => p.Numero == 0);
            Peca peca = Pecas.Single(p => p.Numero == numero);

            byte linhaAnterior = pecaVazia.Linha;
            byte colunaAnterior = pecaVazia.Coluna;

            pecaVazia.Linha = peca.Linha;
            pecaVazia.Coluna = peca.Coluna;

            peca.Linha = linhaAnterior;
            peca.Coluna = colunaAnterior;

            int indiceVazia = Pecas.IndexOf(pecaVazia);
            int indicePeca = Pecas.IndexOf(peca);
            Pecas[indiceVazia] = Pecas[indicePeca];
            Pecas[indicePeca] = pecaVazia;
        }

        private No Clone()
        {
            No filho = new No();

            foreach (Peca p in Pecas)
            {
                filho.AddPeca(p.Numero);
            }

            filho.Pai = this;

            return filho;
        }

        #endregion


        #region Public methods

        public void GerarFilhos()
        {
            Peca pecaVazia = Pecas.Single(p => p.Numero == 0);

            var pecasAdjacentes = Pecas.Where(p =>
                ((p.Linha == pecaVazia.Linha - 1 || p.Linha == pecaVazia.Linha + 1) && (p.Coluna == pecaVazia.Coluna)) ||
                ((p.Coluna == pecaVazia.Coluna - 1 || p.Coluna == pecaVazia.Coluna + 1) && (p.Linha == pecaVazia.Linha))
                ).ToList();

            foreach (Peca p in pecasAdjacentes)
            {
                No filho = Clone();
                filho.MoverPeca(p.Numero);
                filho.Custo = Custo + 1;
                Filhos.Add(filho);
            }
        }

        public void Print()
        {
            Console.WriteLine("---------");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    byte numero = Pecas.Single(p => p.Linha == i && p.Coluna == j).Numero;
                    Console.Write(" {0} ", numero);
                }

                Console.WriteLine();
            }

            Console.WriteLine("---------");
        }

        public override string ToString()
        {
            return Pecas.Aggregate("", (current, p) => current + p.Numero);
        }

        public override bool Equals(object obj)
        {
            return ToString() == ((No) obj).ToString();
        }

        #endregion


    }
}

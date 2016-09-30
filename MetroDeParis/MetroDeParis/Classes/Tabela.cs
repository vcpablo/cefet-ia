using System.Collections.Generic;
using System.Linq;

namespace MetroDeParis.Classes
{
    public class Celula
    {
        public byte Origem { get; set; }
        public byte Destino { get; set; }
        public int Distancia { get; set; }

        public Celula(byte origem, byte destino, int distancia)
        {
            Origem = origem;
            Destino = destino;
            Distancia = distancia;
        }
    }

    public class Tabela
    {
        private List<Celula> Celulas { get; set; }
        private No Chegada { get; set; }


        public Tabela(No chegada)
        {
            Chegada = chegada;

            Celulas = new List<Celula>()
            {
                new Celula(1, 2, 11),
                new Celula(1, 3, 20),
                new Celula(1, 4, 27),
                new Celula(1, 5, 40),
                new Celula(1, 6, 43),
                new Celula(1, 7, 39),
                new Celula(1, 8, 28),
                new Celula(1, 9, 18),
                new Celula(1, 10, 10),
                new Celula(1, 11, 18),
                new Celula(1, 12, 30),
                new Celula(1, 13, 30),
                new Celula(1, 14, 32),

                new Celula(2, 1, 11),
                new Celula(2, 3, 9),
                new Celula(2, 4, 16),
                new Celula(2, 5, 29),
                new Celula(2, 6, 32),
                new Celula(2, 7, 28),
                new Celula(2, 8, 19),
                new Celula(2, 9, 11),
                new Celula(2, 10, 4),
                new Celula(2, 11, 17),
                new Celula(2, 12, 23),
                new Celula(2, 13, 21),
                new Celula(2, 14, 24),

                new Celula(3, 1, 20),
                new Celula(3, 2, 9),
                new Celula(3, 4, 7),
                new Celula(3, 5, 20),
                new Celula(3, 6, 22),
                new Celula(3, 7, 19),
                new Celula(3, 8, 15),
                new Celula(3, 9, 10),
                new Celula(3, 10, 11),
                new Celula(3, 11, 21),
                new Celula(3, 12, 21),
                new Celula(3, 13, 13),
                new Celula(3, 14, 18),

                new Celula(4, 1, 27),
                new Celula(4, 2, 16),
                new Celula(4, 3, 7),
                new Celula(4, 5, 13),
                new Celula(4, 6, 16),
                new Celula(4, 7, 12),
                new Celula(4, 8, 13),
                new Celula(4, 9, 13),
                new Celula(4, 10, 18),
                new Celula(4, 11, 26),
                new Celula(4, 12, 21),
                new Celula(4, 13, 11),
                new Celula(4, 14, 17),

                new Celula(5, 1, 40),
                new Celula(5, 2, 29),
                new Celula(5, 3, 20),
                new Celula(5, 4, 13),
                new Celula(5, 6, 3),
                new Celula(5, 7, 2),
                new Celula(5, 8, 21),
                new Celula(5, 9, 25),
                new Celula(5, 10, 31),
                new Celula(5, 11, 38),
                new Celula(5, 12, 27),
                new Celula(5, 13, 16),
                new Celula(5, 14, 20),

                new Celula(6, 1, 43),
                new Celula(6, 2, 32),
                new Celula(6, 3, 22),
                new Celula(6, 4, 16),
                new Celula(6, 5, 3),
                new Celula(6, 7, 4),
                new Celula(6, 8, 23),
                new Celula(6, 9, 28),
                new Celula(6, 10, 33),
                new Celula(6, 11, 41),
                new Celula(6, 12, 30),
                new Celula(6, 13, 17),
                new Celula(6, 14, 20),

                new Celula(7, 1, 39),
                new Celula(7, 2, 28),
                new Celula(7, 3, 19),
                new Celula(7, 4, 12),
                new Celula(7, 5, 2),
                new Celula(7, 6, 4),
                new Celula(7, 8, 22),
                new Celula(7, 9, 25),
                new Celula(7, 10, 29),
                new Celula(7, 11, 38),
                new Celula(7, 12, 28),
                new Celula(7, 13, 13),
                new Celula(7, 14, 17),

                new Celula(8, 1, 28),
                new Celula(8, 2, 19),
                new Celula(8, 3, 15),
                new Celula(8, 4, 13),
                new Celula(8, 5, 21),
                new Celula(8, 6, 23),
                new Celula(8, 7, 22),
                new Celula(8, 9, 9),
                new Celula(8, 10, 22),
                new Celula(8, 11, 18),
                new Celula(8, 12, 7),
                new Celula(8, 13, 25),
                new Celula(8, 14, 30),

                new Celula(9, 1, 18),
                new Celula(9, 2, 11),
                new Celula(9, 3, 10),
                new Celula(9, 4, 13),
                new Celula(9, 5, 25),
                new Celula(9, 6, 28),
                new Celula(9, 7, 25),
                new Celula(9, 8, 9),
                new Celula(9, 10, 13),
                new Celula(9, 11, 12),
                new Celula(9, 12, 12),
                new Celula(9, 13, 23),
                new Celula(9, 14, 28),

                new Celula(10, 1, 10),
                new Celula(10, 2, 4),
                new Celula(10, 3, 11),
                new Celula(10, 4, 18),
                new Celula(10, 5, 31),
                new Celula(10, 6, 33),
                new Celula(10, 7, 29),
                new Celula(10, 8, 22),
                new Celula(10, 9, 13),
                new Celula(10, 11, 20),
                new Celula(10, 12, 27),
                new Celula(10, 13, 20),
                new Celula(10, 14, 23),

                new Celula(11, 1, 18),
                new Celula(11, 2, 17),
                new Celula(11, 3, 21),
                new Celula(11, 4, 26),
                new Celula(11, 5, 38),
                new Celula(11, 6, 41),
                new Celula(11, 7, 38),
                new Celula(11, 8, 18),
                new Celula(11, 9, 12),
                new Celula(11, 10, 20),
                new Celula(11, 12, 15),
                new Celula(11, 13, 35),
                new Celula(11, 14, 39),

                new Celula(12, 1, 30),
                new Celula(12, 2, 23),
                new Celula(12, 3, 21),
                new Celula(12, 4, 21),
                new Celula(12, 5, 27),
                new Celula(12, 6, 30),
                new Celula(12, 7, 28),
                new Celula(12, 8, 7),
                new Celula(12, 9, 12),
                new Celula(12, 10, 27),
                new Celula(12, 11, 15),
                new Celula(12, 13, 31),
                new Celula(12, 14, 37),

                new Celula(13, 1, 30),
                new Celula(13, 2, 21),
                new Celula(13, 3, 13),
                new Celula(13, 4, 11),
                new Celula(13, 5, 16),
                new Celula(13, 6, 17),
                new Celula(13, 7, 13),
                new Celula(13, 8, 25),
                new Celula(13, 9, 23),
                new Celula(13, 10, 20),
                new Celula(13, 11, 35),
                new Celula(13, 12, 31),
                new Celula(13, 14, 5),

                new Celula(14, 1, 32),
                new Celula(14, 2, 24),
                new Celula(14, 3, 18),
                new Celula(14, 4, 17),
                new Celula(14, 5, 20),
                new Celula(14, 6, 20),
                new Celula(14, 7, 17),
                new Celula(14, 8, 30),
                new Celula(14, 9, 28),
                new Celula(14, 10, 23),
                new Celula(14, 11, 39),
                new Celula(14, 12, 37),
                new Celula(14, 13, 5)
            };
        }


        public int CalcularG(No atual)
        {
            int distancia =
                Celulas.Single(celula => celula.Origem == atual.Pai.Numero && celula.Destino == atual.Numero).Distancia;
            return atual.Pai.G + distancia;
        }

        public int CalcularH(No no)
        {
            int distancia =
                Celulas.Single(celula => celula.Origem == no.Numero && celula.Destino == Chegada.Numero).Distancia;

            return distancia;
        }

        public int CalcularDistancia(No partida, No chegada)
        {
            int distancia =
                Celulas.Single(celula => celula.Origem == partida.Numero && celula.Destino == chegada.Numero).Distancia;

            return distancia;
        }
    }
}

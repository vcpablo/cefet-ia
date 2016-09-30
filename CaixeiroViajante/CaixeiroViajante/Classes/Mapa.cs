using System.Collections.Generic;
using System.Linq;

namespace CaixeiroViajante.Classes
{
    public class Celula
    {
        public byte Anterior { get; set; }
        public byte Atual { get; set; }
        public int Distancia { get; set; }

        public Celula(byte anterior, byte atual, int distancia)
        {
            Anterior = anterior;
            Atual = atual;
            Distancia = distancia;
        }
    }


    public class Mapa
    {
        public List<Celula> Celulas { get; set; }

        public Mapa()
        {
            Celulas = new List<Celula>{
                new Celula(1, 1, 0),
                new Celula(1, 2, 30),
                new Celula(1, 3, 80),
                new Celula(1, 4, 56),
                //new Celula(1, 5, -1),
                //new Celula(1, 6, -1),
                //new Celula(1, 7, -1),
                new Celula(1, 8, 75),
                //new Celula(1, 9, -1),
                new Celula(1, 10, 80),

                new Celula(2, 1, 30),
                new Celula(2, 2, 0),
                new Celula(2, 3, 65),
                //new Celula(2, 4, -1),
                //new Celula(2, 5, -1),
                //new Celula(2, 6, -1),
                new Celula(2, 7, 70),
                //new Celula(2, 8, -1),
                //new Celula(2, 9, -1),
                new Celula(2, 10, 40),

                new Celula(3, 1, 84),
                new Celula(3, 2, 65),
                new Celula(3, 3, 0),
                new Celula(3, 4, 74),
                new Celula(3, 5, 52),
                new Celula(3, 6, 55),
                //new Celula(3, 7, -1),
                new Celula(3, 8, 60),
                new Celula(3, 9, 143),
                new Celula(3, 10, 48),

                new Celula(4, 1, 56),
                //new Celula(4, 2, -1),
                new Celula(4, 3, 74),
                new Celula(4, 4, 0),
                new Celula(4, 5, 135),
                //new Celula(4, 6, -1),
                //new Celula(4, 7, -1),
                new Celula(4, 8, 20),
                //new Celula(4, 9, -1),
                //new Celula(4, 10, -1),

                //new Celula(5, 1, -1),
                //new Celula(5, 2, -1),
                new Celula(5, 3, 52),
                new Celula(5, 4, 135),
                new Celula(5, 5, 0),
                new Celula(5, 6, 70),
                //new Celula(5, 7, -1),
                new Celula(5, 8, 122),
                new Celula(5, 9, 98),
                new Celula(5, 10, 80),

                new Celula(6, 1, 70),
                //new Celula(6, 2, -1),
                new Celula(6, 3, 55),
                //new Celula(6, 4, -1),
                new Celula(6, 5, 70),
                new Celula(6, 6, 0),
                new Celula(6, 7, 63),
                //new Celula(6, 8, -1),
                new Celula(6, 9, 82),
                new Celula(6, 10, 35),

                //new Celula(7, 1, -1),
                new Celula(7, 2, 70),
                //new Celula(7, 3, -1),
                //new Celula(7, 4, -1),
                //new Celula(7, 5, -1),
                new Celula(7, 6, 63),
                new Celula(7, 7, 0),
                //new Celula(7, 8, -1),
                new Celula(7, 9, 120),
                new Celula(7, 10, 57),

                new Celula(8, 1, 75),
                //new Celula(8, 2, -1),
                new Celula(8, 3, 135),
                new Celula(8, 4, 20),
                new Celula(8, 5, 122),
                //new Celula(8, 6, -1),
                //new Celula(8, 7, -1),
                new Celula(8, 8, 0),
                //new Celula(8, 9, -1),
                //new Celula(8, 10, -1),

                //new Celula(9, 1, -1),
                //new Celula(9, 2, -1),
                new Celula(9, 3, 143),
                //new Celula(9, 4, -1),
                new Celula(9, 5, 98),
                new Celula(9, 6, 82),
                new Celula(9, 7, 120),
                //new Celula(9, 8, -1),
                new Celula(9, 9, 0),
                //new Celula(9, 10, -1),

                new Celula(10, 1, 80),
                new Celula(10, 2, 40),
                new Celula(10, 3, 48),
                //new Celula(10, 4, -1),
                new Celula(10, 5, 80),
                new Celula(10, 6, 35),
                new Celula(10, 7, 57),
                //new Celula(10, 8, -1),
                //new Celula(10, 9, -1),
                new Celula(10, 10, 0)
            };
        }

        public List<Celula> GetDestinos(byte origem)
        {
            return Celulas.Where(c => c.Anterior == origem && c.Atual != origem).OrderBy(c => c.Distancia).ToList();
        }

        public Celula GetInicial(byte cidade)
        {
            return Celulas.Single(c => c.Anterior == cidade && c.Atual == cidade);
        }

    }
}

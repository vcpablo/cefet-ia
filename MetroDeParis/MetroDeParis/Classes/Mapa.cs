using System.Collections.Generic;
using System.Linq;

namespace MetroDeParis.Classes
{
    public class Mapa
    {
        private List<No> Nos { get; set; }

        public Mapa()
        {
            No e1 = new No(1);
            No e2 = new No(2);
            No e3 = new No(3);
            No e4 = new No(4);
            No e5 = new No(5);
            No e6 = new No(6);
            No e7 = new No(7);
            No e8 = new No(8);
            No e9 = new No(9);
            No e10 = new No(10);
            No e11 = new No(11);
            No e12 = new No(12);
            No e13 = new No(13);
            No e14 = new No(14);

            //e1
            e1.Adjacencias.Add(e2);

            //e2
            e2.Adjacencias.Add(e3);
            e2.Adjacencias.Add(e9);
            e2.Adjacencias.Add(e10);

            //e3
            e3.Adjacencias.Add(e2);
            e3.Adjacencias.Add(e4);
            e3.Adjacencias.Add(e9);
            e3.Adjacencias.Add(e13);

            //e4
            e4.Adjacencias.Add(e3);
            e4.Adjacencias.Add(e5);
            e4.Adjacencias.Add(e8);
            e4.Adjacencias.Add(e13);

            //e5
            e5.Adjacencias.Add(e4);
            e5.Adjacencias.Add(e6);
            e5.Adjacencias.Add(e7);
            e5.Adjacencias.Add(e8);

            //e6
            e6.Adjacencias.Add(e5);

            //e7
            e7.Adjacencias.Add(e5);

            //e8
            e8.Adjacencias.Add(e4);
            e8.Adjacencias.Add(e5);
            e8.Adjacencias.Add(e9);
            e8.Adjacencias.Add(e12);

            //e9
            e9.Adjacencias.Add(e2);
            e9.Adjacencias.Add(e3);
            e9.Adjacencias.Add(e8);
            e9.Adjacencias.Add(e11);

            //e10
            e10.Adjacencias.Add(e2);

            //e11
            e11.Adjacencias.Add(e9);

            //e12
            e12.Adjacencias.Add(e8);

            //e13
            e13.Adjacencias.Add(e3);
            e13.Adjacencias.Add(e4);
            e13.Adjacencias.Add(e14);

            //e14
            e14.Adjacencias.Add(e13);

            Nos = new List<No>();

            Nos.Add(e1);
            Nos.Add(e2);
            Nos.Add(e3);
            Nos.Add(e4);
            Nos.Add(e5);
            Nos.Add(e6);
            Nos.Add(e7);
            Nos.Add(e8);
            Nos.Add(e9);
            Nos.Add(e10);
            Nos.Add(e11);
            Nos.Add(e12);
            Nos.Add(e13);
            Nos.Add(e14);
        }

        public No GetEstacao(byte numero)
        {
            return Nos.Single(no => no.Numero == numero);
        }
    }
}

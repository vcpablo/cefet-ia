using System.Collections.Generic;

namespace MetroDeParis.Classes
{
    public class No
    {
        public byte Numero { get; set; }
        public int G { get; set; } //custo do nó inicial a esse nó
        public int H { get; set; } //custo estimado deste nó até o final
        public List<No> Adjacencias { get; set; }
        public No Pai { get; set; }

        public No(byte numero)
        {
            Numero = numero;
            Adjacencias = new List<No>();
        }

        public int F()
        {
            return G + H;
        }
    }
}

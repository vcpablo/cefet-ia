using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Puzzle.Classes
{
    public class Peca
    {
        public byte Numero { get; set; }
        public byte Linha { get; set; }
        public byte Coluna { get; set; }

        public Peca(byte numero)
        {
            Numero = numero;
        }

        public Peca Clone()
        {
            return (Peca)MemberwiseClone();
        }
    }
}

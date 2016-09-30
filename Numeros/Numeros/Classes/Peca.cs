using System;

namespace Numeros.Classes
{
    public class Peca
    {
        public byte Valor { get; set; }
        public byte Linha { get; set; }
        public byte Coluna { get; set; }

        public Peca(byte valor)
        {
            Valor = valor;
        }

        public bool PodeTrocarCom(Peca peca)
        {
            if (Math.Abs(Linha - peca.Linha) == 2)
                return false;

            if (Math.Abs(Coluna - peca.Coluna) == 2)
                return false;

            int resultMovida = Coluna + Linha;
            int resultVazia = peca.Coluna + peca.Linha;

            return Math.Abs(resultMovida - resultVazia) == 1;
        }

    }
}

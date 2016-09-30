using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixeiroViajante.Classes
{
    public class HillClimbing
    {
        private Mapa mapa { get; set; }
        public List<Celula> EspacoEstados { get; set; }

        public void Iniciar(byte origem, byte destino)
        {
            mapa = new Mapa();
            EspacoEstados = new List<Celula>();

            Celula cidadeOrigem = mapa.GetInicial(origem);

            EspacoEstados.Add(cidadeOrigem);

            List<Celula> destinos = mapa.GetDestinos(cidadeOrigem.Atual);
            Celula melhorDestino = destinos[0];

            if (melhorDestino.Atual == destino)
            {
                EspacoEstados.Add(melhorDestino);
            }
            else
            {
                Celula segundaOpcao = destinos[1];

                Celula proximoDestino;

                do
                {
                    proximoDestino = SelecionarMelhorOpcao(melhorDestino, segundaOpcao);
                    segundaOpcao = mapa.GetDestinos(melhorDestino.Atual).Where(c => c.Atual != melhorDestino.Anterior).ToList()[1];
                    melhorDestino = proximoDestino;
                } while (proximoDestino.Atual != destino);

                EspacoEstados.Add(proximoDestino);
            }
            
        }
        
        public Celula SelecionarMelhorOpcao(Celula cidadeAtual, Celula segundaOpcao)
        {
            Celula melhorDestino = mapa.GetDestinos(cidadeAtual.Atual).First(c => c.Atual != segundaOpcao.Anterior);

            Celula selecionada;

            if (segundaOpcao.Distancia < melhorDestino.Distancia)
            {
                selecionada = segundaOpcao;
            }
            else
            {
                selecionada = melhorDestino;
                EspacoEstados.Add(cidadeAtual);
            }

            if (EspacoEstados.Any(c => c.Anterior == selecionada.Atual))
            {
                throw new Exception("O algoritmo não encontrou melhoras");
            }
            return selecionada;
        }

    }
}

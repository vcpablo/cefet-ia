package com.willian.ag;

import java.util.ArrayList;
import java.util.Random;

public class Populacao {

    private static int geracao = 1;
    private static Crossover crossover = new Crossover();
    private static ArrayList<Cromossomo> populacao = new ArrayList<>();

    public static Geracao inicializar(){

        Random probabilidadeNegativo = new Random();
		Random random = new Random();
        Roleta roleta = new Roleta();

        System.out.println("População inicial:");

        for (int i = 0; i < Resources.getPopulacaoInicial(); i++){

            int prob = probabilidadeNegativo.nextInt();
            int value = random.nextInt(Resources.getXMaximo());

            if (prob > 50) value = value * -1;

            Cromossomo c = new Cromossomo(value);
            roleta.addArea(c);

            System.out.println(String.format("Indivíduo %d: %s (%d)", i, c.toString(), c.getValor()));
        }

		Cromossomo paiSelecionado = roleta.select();
		Cromossomo maeSelecionada = roleta.select();

        populacao.add(paiSelecionado);
        populacao.add(maeSelecionada);

		return new Geracao(paiSelecionado, maeSelecionada);
	}


    public static void proximaGeracao(Cromossomo pai, Cromossomo mae){
        if(geracao > Resources.getNumeroGeracoes()){
            return;
        }
        else{

            printHeader();

            Geracao geracaoResultante = crossover.gerarFilhos(pai, mae);
            System.out.println("Filhos: " + geracaoResultante.toString());

            Cromossomo a1 = geracaoResultante.getFilho1();
            Cromossomo a2 = geracaoResultante.getFilho2();

            a1.Mutacao();
            a2.Mutacao();

            populacao.add(a1);
            populacao.add(a2);

            geracao++;

            proximaGeracao(a1, a2);
        }
    }

    private static void printHeader(){
        System.out.println("\n-------------------------------------------------");
        System.out.println("Geração " + geracao);
        System.out.println("-------------------------------------------------");
    }

    public static Cromossomo maisCapacitado(){
        Cromossomo resposta = populacao.get(0);
        boolean possuiPontoMaximo = Resources.possuiPontoMaximo();

        for (Cromossomo c : populacao){

            if (possuiPontoMaximo)
            {
                if (c.getValor() > resposta.getValor())
                    resposta = c;
            }
            else{
                if (c.getValor() < resposta.getValor())
                    resposta = c;
            }
        }

        return resposta;
    }
	
}

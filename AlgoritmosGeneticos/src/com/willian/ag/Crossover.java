package com.willian.ag;

import java.util.Random;

public class Crossover {	
	
	public Geracao gerarFilhos(Cromossomo pai, Cromossomo mae){
		
		System.out.println("Fazendo cruzamento entre: " + pai.toString() + " (" + pai.getValor() + ") e " + mae.toString() + " (" + mae.getValor() + ")");
		
		Random random = new Random();
		
		int probabilidade = random.nextInt(100);
		int size = pai.getGenes().size();
		
		Cromossomo filho1;
		Cromossomo filho2;
		
		if(probabilidade <= Resources.getPropabilidadeCrossover()){

			int corte = random.nextInt(size - 1);
			
			System.out.println("Aplicando corte a partir do gene = " + corte);
			
			StringBuilder paiAux = new StringBuilder(pai.toString());
			StringBuilder maeAux = new StringBuilder(mae.toString());
			
			for(int i = corte; i < size; i++){
				char genePai = paiAux.charAt(i);
				char geneMae = maeAux.charAt(i);				
				
				paiAux.setCharAt(i, geneMae);
				maeAux.setCharAt(i, genePai);				
			}
			
			int valorFilho1 = Integer.parseInt(paiAux.toString(), 2);
			int valorFilho2 = Integer.parseInt(maeAux.toString(), 2);
			
			filho1 = new Cromossomo(valorFilho1);
			filho2 = new Cromossomo(valorFilho2);			
		}	
		else{

			System.out.println("Gerando filhos idênticos");

			filho1 = new Cromossomo(pai.getValor());
			filho2 = new Cromossomo(mae.getValor());
		}
		
		return new Geracao(filho1, filho2);
	}
}

package com.willian.ag;

public class Geracao {

	private Cromossomo filho1;
	
	private Cromossomo filho2;

	public Geracao(Cromossomo filho1, Cromossomo filho2){
		this.filho1 = filho1;
		this.filho2 = filho2;
	}
	
	public Cromossomo getFilho1() {
		return filho1;
	}

	public Cromossomo getFilho2() {
		return filho2;
	}

	public String toString(){
        return String.format("%s (%d) e %s (%d)", filho1.toString(), filho1.getValor(), filho2.toString(), filho2.getValor());
    }

}

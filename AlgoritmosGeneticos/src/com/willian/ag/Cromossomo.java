package com.willian.ag;

import java.util.ArrayList;
import java.util.Random;
import java.util.Stack;

public class Cromossomo {

	private ArrayList<Boolean>	genes;	


	public Cromossomo(int valor){

        boolean negativo = valor < 0;

        genes = new ArrayList<>();
        genes.add(negativo);

		String str = Integer.toBinaryString(valor);
        int length = Resources.getNumeroBits();

        if (negativo){
            str = str.substring(str.length() - length);
        }
        else{
            str = String.format("%" + length + "s", str).replace(' ', '0');
        }

		for(int i = 0; i < str.length() ; i++){
            genes.add(str.charAt(i) == '1');
		}
	}


    /**
     * Retorna um ArrayList de bits que representam o valor do cromossomo.
     * @return ArrayList<Boolean>
     */
	public ArrayList<Boolean> getGenes() {
		return genes;
	}


    /**
     * Retorna um inteiro que representa o valor do cromossomo.
     * @return int
     */
	public int getValor(){

        boolean negativo = genes.get(0);
        String value = toString();
        String invertedValue = "";

        if (negativo){
            for (int i = 0; i < value.length(); i++){

                //inverte
                invertedValue += value.charAt(i) == '0' ? '1' : '0';
            }

            Stack<String> pilha = new Stack<>();

            //soma 1
            boolean vaiUm = true;
            for (int i = invertedValue.length() - 1; i >= 0; i--){
                if (invertedValue.charAt(i) == '1'){
                    if (vaiUm)
                        pilha.push("0");
                    else {
                        pilha.push("1");
                        vaiUm = false;
                    }
                }
                else {
                    if (vaiUm){
                        pilha.push("1");
                        vaiUm = false;
                    }
                    else pilha.push("0");
                }
            }

            String finalValue = "";
            while(!pilha.empty()){
                finalValue += pilha.pop();
            }

            return Integer.parseInt(finalValue, 2) * -1;
        }

		return Integer.parseInt(toString(), 2);
	}


    /**
     * Aplica a função de mutação no cromossomo.
     */
    public void Mutacao(){
		for(int i = 0; i < genes.size() ; i++){
        	Random gerador = new Random();		 
            int numero = gerador.nextInt(100);

			if(numero <= Resources.getPropabilidadeMutacao()){
                System.out.println(String.format("Iniciando mutação em: %s (%d)", toString(), getValor()));
				genes.set(i, !genes.get(i));
				System.out.println(String.format("Resultado da mutação: %s (%d)", toString(), getValor()));
			}
		}
	}


    /**
     * Retorna a sequência de bits que representam o valor do cromossomo convertida para String.
     * @return String
     */
	public String toString(){
		StringBuilder sb = new StringBuilder();

        for(boolean b : genes){
            sb.append(b ? "1" : "0");
        }

		return sb.toString();
	}
	
}

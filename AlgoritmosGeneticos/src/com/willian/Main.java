package com.willian;

import com.willian.ag.Geracao;
import com.willian.ag.Populacao;
import com.willian.ag.Resources;

public class Main {

    public static void main(String[] args) {

        Resources.Load("com.willian.resources.resources_ex3");

        System.out.println(Resources.getTitulo() + "\n");

        Geracao primeiraGeracao = Populacao.inicializar();

        System.out.println("Indivíduos selecionados: " + primeiraGeracao.toString());

        Populacao.proximaGeracao(primeiraGeracao.getFilho1(), primeiraGeracao.getFilho2());

        System.out.println("\n*************************************");
        System.out.println(String.format("Indivíduo mais capacitado: %s (%d)", Populacao.maisCapacitado().toString(), Populacao.maisCapacitado().getValor()));
        System.out.println("*************************************");
    }
}

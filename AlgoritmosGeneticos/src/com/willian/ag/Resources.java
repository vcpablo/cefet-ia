package com.willian.ag;

import java.util.ResourceBundle;

/**
 * Created by Willian on 22/03/2016.
 */
public class Resources {

    private static ResourceBundle resources;

    public static void Load(String resourceName){
        resources = ResourceBundle.getBundle(resourceName);
    }

    public static String getTitulo(){ return resources.getString("titulo"); }

    public static int getPropabilidadeCrossover(){
        return Integer.parseInt(resources.getString("probabilidade_crossover"));
    }

    public static int getPropabilidadeMutacao(){
        return Integer.parseInt(resources.getString("probabilidade_mutacao"));
    }

    public static int getNumeroGeracoes(){
        return Integer.parseInt(resources.getString("numero_geracoes"));
    }

    public static int getPopulacaoInicial(){
        return Integer.parseInt(resources.getString("populacao_inicial"));
    }

    public static int getXMaximo(){
        return Integer.parseInt(resources.getString("x_maximo"));
    }

    public static int getNumeroBits(){
        int i = 0;

        while(Math.pow(2, i) < getXMaximo()) i++;

        return i;
    }

    public static String getFuncaoFitness(){
        return resources.getString("funcao_fitness");
    }

    public static boolean possuiPontoMaximo(){
        return Boolean.parseBoolean(resources.getString("possui_ponto_maximo"));
    }
}

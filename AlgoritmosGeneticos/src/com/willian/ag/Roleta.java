package com.willian.ag;

import java.util.ArrayList;
import java.util.Random;

/**
 * Created by Willian on 22/03/2016.
 */
public class Roleta {

    private ArrayList<AreaRoleta> areas;
    private double total;

    public Roleta() {
        areas = new ArrayList<>();
    }


    /**
     * Adiciona uma área na roleta para um cromossomo.
     * @param cromossomo - Cromossomo representado pela área adicionada.
     */
    public void addArea(Cromossomo cromossomo){
        AreaRoleta a = new AreaRoleta(cromossomo);
        areas.add(a);

        total = 0;
        double lastAreaEnd = 0;

        for(AreaRoleta area : areas){
            double fx = Funcao.funcaoFitness(area.getCromossomo().getValor());
            if (fx < 0) fx = fx * -1;
            area.updateRange(lastAreaEnd, lastAreaEnd + fx);
            lastAreaEnd = area.getRange().getFim();
            total += fx;
        }
    }


    /**
     * Seleciona uma área da roleta probabilísticamente.
     * @return Cromossomo representado pela área selecionada.
     */
    public Cromossomo select(){
        Random random = new Random();
        double numero = (double)random.nextInt((int)total);

        for(AreaRoleta area : areas){
            if(area.test(numero)) return area.getCromossomo();
        }

        return null;
    }

}

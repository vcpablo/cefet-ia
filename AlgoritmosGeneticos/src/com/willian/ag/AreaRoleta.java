package com.willian.ag;

/**
 * Created by Willian on 22/03/2016.
 */
public class AreaRoleta {

    private Cromossomo cromossomo;

    private Range range;

    public AreaRoleta(Cromossomo cromossomo) {
        this.cromossomo = cromossomo;
        range = new Range();
    }

    public Cromossomo getCromossomo() {
        return cromossomo;
    }

    public Range getRange() {
        return range;
    }

    public boolean test(double numeroSorteado){
        return numeroSorteado >= range.getInicio() && numeroSorteado <= range.getFim();
    }

    public void updateRange(double inicio, double fim){
        range.setInicio(inicio);
        range.setFim(fim);
    }
}

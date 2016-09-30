package com.willian.ag;

import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;
import javax.script.SimpleBindings;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by Willian on 23/03/2016.
 */
public class Funcao {

    private static ScriptEngine engine = new ScriptEngineManager().getEngineByName("JavaScript");

    public static double funcaoFitness(int x_value){
        Map<String, Object> vars = new HashMap<>();
        vars.put("x", x_value);
        vars.put("y", x_value);

        try {
            return (double)engine.eval(Resources.getFuncaoFitness(), new SimpleBindings(vars));
        } catch (ScriptException e) {
            e.printStackTrace();
            return 0;
        }
    }

}

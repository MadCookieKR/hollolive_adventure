using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface Scenario
{
    void excute(int scriptIndex);
}

[Serializable]
public class ScenarioArgument
{
    public SpriteRenderer backgroundRenderer;

    public ScenarioArgument(SpriteRenderer backgroundRenderer)
    {
        this.backgroundRenderer = backgroundRenderer;
    }
}

public class ScenarioFactory
{
    static public Scenario createScenario(string actName, ScenarioArgument arg)
    {
        switch (actName)
        {
            case "A1":
                return new ScenarioA1(arg);
            default:
                return new ScenarioA1(arg);
        }
    }
}
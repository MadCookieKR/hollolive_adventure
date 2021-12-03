using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioA1 : Scenario
{
    public ScenarioA1(ScenarioArgument arg)
    {
        this.arg = arg;
    }

    ScenarioArgument arg;

    public void excute(int scriptIndex)
    {
        switch (scriptIndex)
        {
            case 0:
                arg.backgroundRenderer.sprite = SpriteLoader.load("Images/A1/Backgrounds/gura_pizza");
                break;
        }
    }
}

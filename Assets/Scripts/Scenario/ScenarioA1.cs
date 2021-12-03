using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioA1 : Scenario
{
    [SerializeField]
    private SpriteRenderer backgroundRenderer;

    public override void excute(int scriptIndex)
    {
        switch (scriptIndex)
        {
            case 1:
                backgroundRenderer.sprite = SpriteLoader.load("Images/A1/Backgrounds/gura_pizza");
                break;
        }
    }
}

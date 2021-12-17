using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioA2 : Scenario
{
    [Serializable]
    public enum AUDIO
    {
        
    }

    [SerializeField]
    SimpleScenarioDelegate<AUDIO> scenarioDelegate;


    private void Start()
    {
        scenarioDelegate.onStart(this);
    }


    private void Update()
    {
        scenarioDelegate.onUpdate(this);
    }


    public override void excute(int scriptIndex)
    {
        switch (scriptIndex)
        {
            case 1:
                break;
        }
    }

 
}

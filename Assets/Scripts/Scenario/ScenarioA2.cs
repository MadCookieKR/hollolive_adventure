using System;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            excute(scenarioDelegate.getCurrentScriptIndex());
        }

        scenarioDelegate.onUpdate(this);
    }


    public override void excute(int scriptIndex)
    {
        switch (scriptIndex)
        {
            case 3:
                break;
        }
    }


}

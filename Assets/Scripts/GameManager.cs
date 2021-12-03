using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextVisualizer textVisualizer;
    public Scenario scenario;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            updateState(textVisualizer.currentScript);
        }
    }

    private void updateState(Script script)
    {
        scenario.excute(textVisualizer.scriptIndex);
    }
}

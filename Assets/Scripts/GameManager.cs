using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TextVisualizer textVisualizer;
    public Scenario scenario;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (textVisualizer.currentScript != null)
            {
                updateState(textVisualizer.scriptIndex);
                textVisualizer.incrementScriptIndex();
            }
        }
    }

    private void updateState(int scriptIndex)
    {
        scenario.excute(scriptIndex);
    }
}

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
                updateState((Script)textVisualizer.currentScript);
            }
        }
    }

    private void updateState(Script script)
    {
        scenario.excute(textVisualizer.scriptIndex + 1);
    }
}

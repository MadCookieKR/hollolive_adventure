using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class TextVisualizer : MonoBehaviour
{
    public Text speakerText;
    public Text contentText;
    public float textSpeed = 0.05F;

    public Scenario scenario;

    [HideInInspector]
    public List<Script> scripts = new List<Script>();

    private int scriptIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        scripts = new ScriptLoader().loadScript();
       
        if (scripts.Count > 0)
        {
            updateScript(scripts[scriptIndex]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (scriptIndex >= scripts.Count)
            {
                return;
            }

            updateScript(scripts[scriptIndex]);
        }
    }

    IEnumerator showContent(string script)
    {
        int textIndex = 1;

        while (textIndex <= script.Length)
        {
            contentText.text = script.Substring(0, textIndex++);
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void updateScript(Script script)
    {
        StopCoroutine("showContent");
        speakerText.text = script.speaker;
        StartCoroutine("showContent", script.content);
        scenario.excute(scriptIndex + 1);
        scriptIndex++;
    }
}

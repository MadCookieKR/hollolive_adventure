using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVisualizer : MonoBehaviour
{
    public Text speakerText;
    public Text contentText;
    public float secondPerChar = 0.02F;

    private List<Script> scripts = new List<Script>();
    public Script currentScript { get { return scripts[scriptIndex]; } }

    private int _scriptIndex = 0;
    public int scriptIndex { get { return _scriptIndex; } }

    // Start is called before the first frame update
    void Start()
    {
        scripts = new ScriptLoader().loadScript();

        if (scripts.Count > 0)
        {
            updateState(scripts[scriptIndex]);
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

            updateState(scripts[scriptIndex]);
        }
    }

    IEnumerator showContent(string script)
    {
        int textIndex = 1;

        while (textIndex <= script.Length)
        {
            contentText.text = script.Substring(0, textIndex++);
            yield return new WaitForSeconds(secondPerChar);
        }
    }

    private void updateState(Script script)
    {
        StopCoroutine("showContent");
        speakerText.text = script.speaker;
        StartCoroutine("showContent", script.content);
        _scriptIndex++;
    }


}

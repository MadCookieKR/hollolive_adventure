using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVisualizer : MonoBehaviour
{
    public Text speakerText;
    public Text contentText;
    public float secondPerChar = 0.02F;
    public bool updateStateOnAwake = false;

    private List<Script> scripts = new List<Script>();
    public Script? currentScript
    {
        get
        {
            if (scriptIndex < scripts.Count)
            {
                return scripts[scriptIndex];
            }
            else
            {
                return null;
            }
        }
    }

    //1부터 시작한다.
    private int _scriptIndex = 33;
    public int scriptIndex { get { return _scriptIndex; } }
    public void incrementScriptIndex()
    {
        _scriptIndex++;
    }

   
    void Start()
    {
        //인덱스 시작을 1로 맞추기 위한 더미 스크립트
        scripts.Add(new Script());
        scripts.AddRange(new ScriptLoader().loadScript());


        if (updateStateOnAwake && scripts.Count > 0)
        {
            updateState(scripts[scriptIndex]);
        }
    }

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
    }


}

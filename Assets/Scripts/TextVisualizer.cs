using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TextVisualizer
{
    public Text speakerText;
    public Text contentText;
    public float secondPerChar = 0.02F;
    public bool isUpdateStateOnAwake = true;
    public TextAsset script;

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

    //스크립트 라인넘버와 맞추기 위해 1부터 시작
    private int _scriptIndex = 1;
    public int scriptIndex { get { return _scriptIndex; } }
    public void incrementScriptIndex()
    {
        _scriptIndex++;
    }


    private IEnumerator updateStateCoroutine;

    public void onStart(MonoBehaviour monoBehaviour)
    {
        //인덱스가 1부터 시작하기 위해 빈 스크립트 추가
        scripts.Add(new Script());
        scripts.AddRange(new ScriptLoader(script).loadScript());

        updateStateCoroutine = updateState(scripts[scriptIndex]);
        if (isUpdateStateOnAwake && scripts.Count > 0)
        {
            monoBehaviour.StartCoroutine(updateStateCoroutine);
        }
    }

    public void onUpdate(MonoBehaviour monoBehaviour)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (scriptIndex >= scripts.Count)
            {
                return;
            }

            if (updateStateCoroutine != null)
            {
                monoBehaviour.StopCoroutine(updateStateCoroutine);
            }
            updateStateCoroutine = updateState(scripts[scriptIndex]);
            monoBehaviour.StartCoroutine(updateStateCoroutine);
        }
    }


    IEnumerator updateState(Script script)
    {
        speakerText.text = script.speaker;
        yield return showContent(script.content);
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


}

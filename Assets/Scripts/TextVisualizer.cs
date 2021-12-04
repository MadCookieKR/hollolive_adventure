using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVisualizer : MonoBehaviour
{
    public Text speakerText;
    public Text contentText;
    public float secondPerChar = 0.02F;
    public bool isUpdateStateOnAwake = false;

    /// <summary>
    /// true : ���� ��ũ��Ʈ�� ���̾�α׿� ���� �ʴ´�.
    /// </summary>
    [HideInInspector]
    public bool isBlock { get; set; } = false;

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

    //1���� �����Ѵ�.
    private int _scriptIndex = 30;
    public int scriptIndex { get { return _scriptIndex; } }
    public void incrementScriptIndex()
    {
        _scriptIndex++;
    }

   
    void Start()
    {
        //�ε��� ������ 1�� ���߱� ���� ���� ��ũ��Ʈ
        scripts.Add(new Script());
        scripts.AddRange(new ScriptLoader().loadScript());


        if (isUpdateStateOnAwake && scripts.Count > 0)
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
        if (isBlock)
        {
            return;
        }
        StopCoroutine("showContent");
        speakerText.text = script.speaker;
        StartCoroutine("showContent", script.content);
    }


}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class TextVisualizer : MonoBehaviour
{
    public Text speakerText;
    public Text contentText;
    public float textSpeed = 0.05F;

    [HideInInspector]
    public List<Script> scripts = new List<Script>();

    private int scriptIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        scripts = new ScriptLoader().loadScript();
       
        if (scripts.Count > 0)
        {
            speakerText.text = scripts[0].speaker;
            contentText.text = scripts[0].content;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (scriptIndex >= scripts.Count)
            {
                return;
            }

            StopCoroutine("showContent");
            speakerText.text = scripts[scriptIndex].speaker;
            StartCoroutine("showContent", scripts[scriptIndex].content);
            scriptIndex++;
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
}

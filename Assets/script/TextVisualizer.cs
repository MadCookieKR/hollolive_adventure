using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class TextVisualizer : MonoBehaviour
{
    public Text text;
    public float textSpeed = 0.05F;
    public List<string> scripts = new List<string>();

    private int scriptIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (scripts.Count > 0)
        {
            text.text = scripts[0];
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

            StartCoroutine("showScript", scripts[scriptIndex++]);
        }
    }

    IEnumerator showScript(string script)
    {
        int textIndex = 1;

        while (textIndex <= script.Length)
        {
            text.text = script.Substring(0, textIndex++);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

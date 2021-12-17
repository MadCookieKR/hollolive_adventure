using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ScriptLoader
{
    public ScriptLoader(TextAsset textAsset)
    {
        this.textAsset = textAsset;
    }

    TextAsset textAsset;

    // Start is called before the first frame update
    public List<Script> loadScript()
    {
        //TextAsset scriptText = Resources.Load<TextAsset>("InGameScripts/" + scriptPath);

        ScriptParser parser = new ScriptParser();

        return textAsset.text.Split('\n').Select(line =>parser.parse(line)).ToList();
    }

}

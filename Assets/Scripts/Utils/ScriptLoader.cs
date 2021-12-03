using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ScriptLoader
{
    private string actFolderPath = "A1";
    private string currentScript = "1";

    // Start is called before the first frame update
    public List<Script> loadScript()
    {
        TextAsset scriptText = Resources.Load<TextAsset>("InGameScripts/" + actFolderPath + "/" + currentScript);

        ScriptParser parser = new ScriptParser();

        return scriptText.text.Split('\n').Select(line =>parser.parse(line)).ToList();
    }

}

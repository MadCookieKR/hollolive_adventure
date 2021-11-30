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
        string scriptFilePath = "Assets/InGameScript/" + actFolderPath + "/" + currentScript + ".txt";

        ScriptParser parser = new ScriptParser();

        return File.ReadAllLines(scriptFilePath).Select(line =>parser.parse(line)).ToList();
    }

}

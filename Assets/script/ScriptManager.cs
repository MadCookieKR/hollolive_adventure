using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ScriptManager : MonoBehaviour
{
    public TextVisualizer textVisualizer;
    private string actFolderPath = "A1";
    private int currentScriptIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        string scriptFilePath = "Assets/InGameScript/" + actFolderPath + "/" + currentScriptIndex + ".txt";

        textVisualizer.scripts = File.ReadAllLines(scriptFilePath).ToList();        
    }

}

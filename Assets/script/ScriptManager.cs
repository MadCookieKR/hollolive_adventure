using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ScriptManager : MonoBehaviour
{
    public TextVisualizer textVisualizer;
    public TextAsset text;

    // Start is called before the first frame update
    void Start()
    {
        textVisualizer.scripts = text.text.Split('\n').ToList();        
    }

}

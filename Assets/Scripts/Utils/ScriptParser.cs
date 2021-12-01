using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public struct Script
{
    public Script(string speaker, string content, Sprite background)
    {
        this.speaker = speaker;
        this.content = content;
        this.background = background;
    }

    public string speaker { get; }
    public string content { get; }
    public Sprite background { get; }

    public string toString() { return "script: {" + "speaker: " + speaker + " / content: " + content + " / background: " + background.name + "}"; }
}

public class ScriptParser
{
    private SpriteLoader spriteLoader = new SpriteLoader();

    public Script parse(string line)
    {
        string pattern = "(.*): (.*) \\[(.*)\\]";
        Match match = Regex.Match(line, pattern);
        string speaker = match.Groups[1].Value;
        string content = match.Groups[2].Value;
        string background = match.Groups[3].Value;
        Sprite backgroundSprite = spriteLoader.load("Images/Backgrounds/" + background);
        Debug.Log(speaker + "/" + content + "/" + background);
        Script script = new Script(speaker, content, backgroundSprite);
        return script;
    }
}

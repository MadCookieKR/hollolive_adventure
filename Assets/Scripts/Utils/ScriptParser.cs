using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public struct Script
{
    public Script(string speaker, string content)
    {
        this.speaker = speaker;
        this.content = content;
    }

    public string speaker { get; }
    public string content { get; }
}

public class ScriptParser
{
    public Script parse(string line)
    {
        string pattern = "(.*): (.*)";
        Match match = Regex.Match(line, pattern);
        string speaker = match.Groups[1].Value;
        string content = match.Groups[2].Value;
        Script script = new Script(speaker, content);
        return script;
    }
}

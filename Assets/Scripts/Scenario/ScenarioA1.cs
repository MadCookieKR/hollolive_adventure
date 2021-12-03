using System;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioA1 : Scenario
{
    [Serializable]
    public enum AUDIO
    {
        BGM_LOADING, FX_GURA_PIZZA
    }
    [SerializeField]
    private SpriteRenderer backgroundRenderer;

    [SerializeField]
    private List<AUDIO> audioKeys;
    [SerializeField]
    private List<AudioSource> audioValues;

    private Dictionary<AUDIO, AudioSource> audioDict = new Dictionary<AUDIO, AudioSource>();

    void Start()
    {
        for(int i = 0; i<audioKeys.Count; i++)
        {
            audioDict.Add(audioKeys[i], audioValues[i]);
        }
    }


    public override void excute(int scriptIndex)
    {

        switch (scriptIndex)
        {
            case 1:
                backgroundRenderer.sprite = SpriteLoader.load("Images/A1/Backgrounds/gura_pizza");
                audioDict[AUDIO.FX_GURA_PIZZA].Play();
                break;
        }
    }
}

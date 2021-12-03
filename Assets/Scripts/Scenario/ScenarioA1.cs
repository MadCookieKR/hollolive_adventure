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
    private GameObject scriptDialog;
    [SerializeField]
    private List<AUDIO> audioKeys;
    [SerializeField]
    private List<AudioSource> audioValues;

    private Dictionary<AUDIO, AudioSource> audioDict = new Dictionary<AUDIO, AudioSource>();

    void Start()
    {
        for (int i = 0; i < audioKeys.Count; i++)
        {
            audioDict.Add(audioKeys[i], audioValues[i]);
        }

        backgroundRenderer.sprite = SpriteLoader.load("Images/A1/Backgrounds/gura_pizza");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (scriptDialog.activeSelf == false)
            {
                scriptDialog.SetActive(true);
            }
        }
    }


    public override void excute(int scriptIndex)
    {

        switch (scriptIndex)
        {
            case 6:
                audioDict[AUDIO.FX_GURA_PIZZA].Play();
                break;
        }
    }
}

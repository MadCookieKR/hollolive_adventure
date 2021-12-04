using System;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioA1 : Scenario
{
    [Serializable]
    public enum AUDIO
    {
        BGM_LOADING, FX_GURA_PIZZA, PX_GURA_PIZZA_TIME
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

    private AppTransform mainCamTransform;

    void Start()
    {
        for (int i = 0; i < audioKeys.Count; i++)
        {
            audioDict.Add(audioKeys[i], audioValues[i]);
        }

        mainCamTransform = new AppTransform(Camera.main.transform);
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
        Debug.Log("scenario scriptIndex : " + scriptIndex);
        switch (scriptIndex)
        {
            case 3:
                audioDict[AUDIO.PX_GURA_PIZZA_TIME].Play();
                break;
            case 7:
                audioDict[AUDIO.FX_GURA_PIZZA].Play();
                break;
            case 34:
                backgroundRenderer.sprite = SpriteLoader.load("Images/A1/Backgrounds/gura_song");
                mainCamTransform.translate(new Vector2(0, -9));
                StartCoroutine(mainCamTransform.moveSmooth(new Vector2(0, 7), 2));
                break;
        }
    }
}

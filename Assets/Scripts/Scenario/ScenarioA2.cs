using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioA2 : Scenario
{
    [Serializable]
    public enum AUDIO
    {

    }

    [SerializeField]
    private List<Sprite> sprites;
    [SerializeField]
    private SpriteRenderer backgroundRenderer;
    [SerializeField]
    private GameObject scriptDialog;
    [SerializeField]
    private TextVisualizer textVisualizer;
    [SerializeField]
    SerializableDictionary<AUDIO, AudioSource> audioStore;
    [SerializeField]
    private Image transitionImage;

    private AppTransform mainCamTransform;

    void Start()
    {
        audioStore.init();

        mainCamTransform = new AppTransform(Camera.main.transform);
        backgroundRenderer.sprite = sprites[0];

        textVisualizer.onStart(this);
        textVisualizer.incrementScriptIndex();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            textVisualizer.onUpdate(this);
            textVisualizer.incrementScriptIndex();
        }
    }


    public override void excute(int scriptIndex)
    {
       
    }

 
}

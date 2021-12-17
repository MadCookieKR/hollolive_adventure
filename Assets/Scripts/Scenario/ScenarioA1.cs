using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioA1 : Scenario
{
    [Serializable]
    public enum AUDIO
    {
        BGM_LOADING, FX_GURA_PIZZA, PX_GURA_PIZZA_TIME, BGM_GALAXY, FX_GURA_HUM
    }

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

    private bool isUpdatePause = false;
    private bool isTextVisualizerPause = false;

    void Start()
    {
        audioStore.init();

        mainCamTransform = new AppTransform(Camera.main.transform);
        backgroundRenderer.sprite = SpriteLoader.load("Images/A1/Backgrounds/gura_pizza");
        scriptDialog.SetActive(false);

        textVisualizer.onStart(this);
    }

    private void Update()
    {
        if (!audioStore.get(AUDIO.BGM_GALAXY).isPlaying)
        {
            isUpdatePause = false;
        }

        if (isUpdatePause)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (textVisualizer.currentScript != null)
            {
                excute(textVisualizer.scriptIndex);
                if (!isTextVisualizerPause)
                {
                    textVisualizer.onUpdate(this);
                }

                textVisualizer.incrementScriptIndex();
            }



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
            case 3:
                audioStore.get(AUDIO.PX_GURA_PIZZA_TIME).Play();
                break;
            case 7:
                audioStore.get(AUDIO.FX_GURA_PIZZA).Play();
                break;
            case 35:
                StartCoroutine(startTransition());
                isTextVisualizerPause = true;
                break;
            case 36:
                isTextVisualizerPause = false;
                break;
            case 51:
                audioStore.get(AUDIO.FX_GURA_HUM).Play();
                break;
            case 57:
                audioStore.get(AUDIO.BGM_LOADING).Stop();
                audioStore.get(AUDIO.FX_GURA_HUM).Stop();
                audioStore.get(AUDIO.BGM_GALAXY).Play();
                break;
            case 60:
                isUpdatePause = true;
                isTextVisualizerPause = true;
                break;
            case 61:
                audioStore.get(AUDIO.BGM_LOADING).Play();
                isUpdatePause = false;
                isTextVisualizerPause = false;
                break;
            case 66:
                transitionImage.color = new Color(255, 255, 255, 0);
                StartCoroutine(Transition.fadeOut(3f, transitionImage));
                break;


        }
    }

    private IEnumerator startTransition()
    {
        transitionImage.color = new Color(0,0,0,0);
        yield return Transition.fadeOut(0.5f / 2, transitionImage);
        backgroundRenderer.sprite = SpriteLoader.load("Images/A1/Backgrounds/gura_song");
        mainCamTransform.translate(new Vector2(0, -9));
        yield return Transition.fadeIn(0.5f / 2, transitionImage);
        yield return mainCamTransform.moveSmooth(new Vector2(0, 7), 0.5f);
    }
}

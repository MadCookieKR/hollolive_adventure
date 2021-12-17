using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class SimpleScenarioDelegate<T>
{
    [SerializeField]
    private List<Sprite> backgrounds;
    [SerializeField]
    private SpriteRenderer backgroundRenderer;
    [SerializeField]
    private TextVisualizer textVisualizer;
    [SerializeField]
    SerializableDictionary<T, AudioSource> audioStore;
    [SerializeField]
    private GameObject scriptDialog;
    [SerializeField]
    private Image transitionImage;

    private AppTransform mainCamTransform;

    public void onStart(MonoBehaviour monoBehaviour)
    {
        audioStore.init();

        mainCamTransform = new AppTransform(Camera.main.transform);
        backgroundRenderer.sprite = backgrounds[0];

        textVisualizer.onStart(monoBehaviour);
        textVisualizer.incrementScriptIndex();
    }

    public void onUpdate(MonoBehaviour monoBehaviour)
    {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            textVisualizer.onUpdate(monoBehaviour);
            textVisualizer.incrementScriptIndex();
        }
    }

}

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

    private int backgroundIndex = 0;

    public void onStart(MonoBehaviour monoBehaviour)
    {
        audioStore.init();

        mainCamTransform = new AppTransform(Camera.main.transform);
        backgroundRenderer.sprite = backgrounds[backgroundIndex++];

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

    public int getCurrentScriptIndex()
    {
        return textVisualizer.scriptIndex;
    }



    public IEnumerator basicTransition()
    {
        transitionImage.color = new Color(0, 0, 0, 0);
        yield return Transition.fadeOut(0.5f / 2, transitionImage);
        backgroundRenderer.sprite = backgrounds[backgroundIndex++];
        yield return Transition.fadeIn(0.5f / 2, transitionImage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="minY">bottom of camera movement</param>
    /// <param name="maxY">top of camera movement</param>
    /// <param name="speed">unit per second</param>
    /// <returns></returns>
    public IEnumerator moveUpTransition(float minY, float maxY, float speed)
    {
        transitionImage.color = new Color(0, 0, 0, 0);
        yield return Transition.fadeOut(0.5f / 2, transitionImage);
        backgroundRenderer.sprite = backgrounds[backgroundIndex++];
        mainCamTransform.translate(new Vector2(0, minY));
        yield return Transition.fadeIn(0.5f / 2, transitionImage);
        yield return mainCamTransform.moveSmooth(new Vector2(0, maxY), speed);
    }

}

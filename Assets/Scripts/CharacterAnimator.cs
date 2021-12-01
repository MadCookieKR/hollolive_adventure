using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private FadeOut fadeOut;
    private FadeIn fadeIn;
    private AppTransform appTransform;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut = new FadeOut(spriteRenderer);
        fadeIn = new FadeIn(spriteRenderer);
        appTransform = new AppTransform(GetComponent<Transform>());
        StartCoroutine(fadeIn.start(0.5f));
        //StartCoroutine(fadeOut.start(0.5f));
        //StartCoroutine(appTransform.moveSmooth(new Vector2(10, 0), 10));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

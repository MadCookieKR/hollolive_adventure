using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private FadeOut fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut = new FadeOut(spriteRenderer);
        StartCoroutine(fadeOut.start(0.5f));     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

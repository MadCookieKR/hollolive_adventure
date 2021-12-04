using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeOut
{
    private SpriteRenderer spriteRenderer;
    public FadeOut(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
    }

    public IEnumerator start(float duration)
    {
        float amount = 0.02f;
        while(spriteRenderer.color.a > 0f)
        {
            Color c = spriteRenderer.color;
            c.a -= amount;
            spriteRenderer.color = c;

            yield return new WaitForSeconds(duration * amount);
        }
        
    }



}

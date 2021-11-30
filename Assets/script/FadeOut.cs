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
        float alpha = 1f;
        float amount = 0.1f;
        while(alpha > 0f)
        {
            alpha -= amount;
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;

            yield return new WaitForSeconds(duration * amount);
        }
        
    }



}

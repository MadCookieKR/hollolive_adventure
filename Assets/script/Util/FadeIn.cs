using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn
{
    private SpriteRenderer spriteRenderer;
    public FadeIn(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
    }

    public IEnumerator start(float duration)
    {
        float alpha = 0f;
        float amount = 0.1f;
        while (alpha <= 1f)
        {
            alpha += amount;
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;

            yield return new WaitForSeconds(duration * amount);
        }

    }
}

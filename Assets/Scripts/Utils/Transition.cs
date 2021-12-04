using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition
{
    private Image transitionImage;

    public Transition(Image transitionImage)
    {
        this.transitionImage = transitionImage;
    }


    public IEnumerator fadeOut(float duration)
    {
        float amount = 0.1f;
        while (transitionImage.color.a <= 1f)
        {
            Color c = transitionImage.color;
            c.a += amount;
            transitionImage.color = c;

            yield return new WaitForSeconds(duration * 0.1f);
        }
    }

    public IEnumerator fadeIn(float duration)
    {
        float amount = 0.1f;
        while (transitionImage.color.a > 0f)
        {
            Color c = transitionImage.color;
            c.a -= amount;
            transitionImage.color = c;

            yield return new WaitForSeconds(duration * 0.1f);
        }

    }
}
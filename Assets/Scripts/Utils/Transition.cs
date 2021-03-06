using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition
{

    public static IEnumerator fadeOut(float duration, Image transitionImage)
    {
        float amount = 0.02f;
        while (transitionImage.color.a <= 1f)
        {
            Color c = transitionImage.color;
            c.a += amount;
            transitionImage.color = c;

            yield return new WaitForSeconds(duration * amount);
        }
    }

    public static IEnumerator fadeIn(float duration, Image transitionImage)
    {
        float amount = 0.02f;
        while (transitionImage.color.a > 0f)
        {
            Color c = transitionImage.color;
            c.a -= amount;
            transitionImage.color = c;

            yield return new WaitForSeconds(duration * amount);
        }

    }
}
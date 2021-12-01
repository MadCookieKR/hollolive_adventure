using System.Collections;
using UnityEngine;

public class AppTransform
{

    private Transform transform;

    public AppTransform(Transform transform)
    {
        this.transform = transform;
    }

    public IEnumerator moveSmooth(Vector2 target, float speed)
    {
        while (true)
        {
            Vector2 oldPosition = transform.position;
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if(Vector2.Distance(transform.position, oldPosition) < 0.1f)
            {
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

}

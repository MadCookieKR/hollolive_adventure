using System.Collections;
using UnityEngine;

public class AppTransform
{

    private Transform transform;

    public AppTransform(Transform transform)
    {
        this.transform = transform;
    }


    public void translate(Vector2 target)
    {
        transform.Translate(target.x, target.y, transform.position.z);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed">unit per second</param>
    /// <returns></returns>
    public IEnumerator moveSmooth(Vector2 target, float speed)
    {
        Vector3 targetPos = new Vector3(target.x, target.y, transform.position.z);
        while (true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            if(Vector2.Distance(transform.position, targetPos) < 0.1f)
            {
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

}

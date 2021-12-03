using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scenario : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="scriptIndex">starts from 1</param>
    abstract public void excute(int scriptIndex);
}


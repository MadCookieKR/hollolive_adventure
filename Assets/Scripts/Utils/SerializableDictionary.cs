using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializableDictionary<T, R>
{
    [SerializeField]
    private List<T> keys;
    [SerializeField]
    private List<R> values;

    private Dictionary<T, R> dictionary = new Dictionary<T, R>();

   public void init()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            dictionary.Add(keys[i], values[i]);
        }
    }

    public R get(T key)
    {
        R result = default;
        dictionary.TryGetValue(key, out result);
        return result;
    }

}
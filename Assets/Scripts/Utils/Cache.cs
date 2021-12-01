using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache<T>
{
    Dictionary<string, T> cache = new Dictionary<string, T>();

    public T get(string key)
    {
        if (cache.ContainsKey(key))
        {
            return cache[key];
        }
        else
        {
            return default;
        }
    }

    public void put(string key, T value)
    {
        cache.Add(key, value);
    }


}

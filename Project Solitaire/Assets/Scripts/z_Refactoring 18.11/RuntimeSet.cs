using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> set = new List<T>();

    public void Add(T t)
    { set.Add(t); }

    public void Remove(T t)
    { set.Remove(t); }
}

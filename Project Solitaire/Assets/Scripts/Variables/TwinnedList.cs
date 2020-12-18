using System;
using System.Collections.Generic;
using UnityEngine;

public class TwinnedList<TFirst, TSecond>
{
    protected IList<TFirst> firsts;
    protected IList<TSecond> seconds;

    #region Constructors
    public TwinnedList() 
    {
        firsts = new List<TFirst>();
        seconds = new List<TSecond>();
    }

    public TwinnedList(TwinnedList<TFirst, TSecond> twinList)
    {
        firsts = new List<TFirst>(twinList.FirstValues);
        seconds = new List<TSecond>(twinList.SecondValues);
    }
    public TwinnedList(IList<TFirst> firstList, IList<TSecond> secondList)
    {
        firsts = new List<TFirst>(firstList);
        seconds = new List<TSecond>(secondList);
    }
    #endregion

    public List<TFirst> FirstValues { get { return (List<TFirst>)firsts; } }
    public List<TSecond> SecondValues { get { return (List<TSecond>)seconds; } }

    public int Count
    {
        get { return firsts.Count; }
    }
    public TwinnedList<TFirst, TSecond> this[int index]
    {
        get 
        {
            TFirst first = FirstValues[index];
            TSecond second = SecondValues[index];
            TwinnedList<TFirst, TSecond> list = new TwinnedList<TFirst, TSecond>();
            list.Add(first, second);

            return list;
        }
    }
    public bool Contains(TFirst first)
    {
        return FirstContains(first);
    }
    public bool Contains(TSecond second)
    {
        return SecondContains(second);
    }
    public bool FirstContains(TFirst first)
    {
        return firsts.Contains(first);
    }
    public bool SecondContains(TSecond second)
    {
        return seconds.Contains(second);
    }
    public void Add(TFirst first, TSecond second)
    {
        if (firsts == null)
            firsts = new List<TFirst>();
        if(seconds == null)
            seconds = new List<TSecond>();

        firsts.Add(first);
        seconds.Add(second);
    }
    public void RemoveAt(int index)
    {
        firsts.RemoveAt(index);
        seconds.RemoveAt(index);
    }
    public void RemoveAtFirst(TFirst first)
    {
        firsts.RemoveAt(firsts.IndexOf(first));
        seconds.RemoveAt(firsts.IndexOf(first));
    }
    public void RemoveAtSecond(TSecond second)
    {
        firsts.RemoveAt(seconds.IndexOf(second));
        seconds.RemoveAt(seconds.IndexOf(second));
    }
    public IList<TSecond> GetAll(TFirst first)
    {
        return GetAllFromFirst(first);
    }
    public IList<TFirst> GetAll(TSecond second)
    {
        return GetAllFromSecond(second);
    }
    public IList<TSecond> GetAllFromFirst(TFirst first)
    {
        if (!firsts.Contains(first)) { Debug.LogError(this + " does not contain a value of " + first + " in FirstValues"); return default; }

        IList<TSecond> list = new List<TSecond>();
        for(int i = 0; i < firsts.Count; i++)
        {
            if (firsts[i].Equals(first))
            {
                list.Add(seconds[i]);
            }
        }

        return list;
    }
    public IList<TFirst> GetAllFromSecond(TSecond second)
    {
        if (!seconds.Contains(second)) { Debug.LogError(this + " does not contain a value of " + second + " in SecondValues"); return default; }

        IList<TFirst> list = new List<TFirst>();
        for(int i = 0; i < seconds.Count; i++)
        {
            if (seconds[i].Equals(seconds))
            {
                list.Add(firsts[i]);
            }
        }

        return list;
    }
}

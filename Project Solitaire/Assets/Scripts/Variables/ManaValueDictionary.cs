using System;
using System.Collections.Generic;
using UnityEngine;

public class ManaValueDictionary : TwinnedList<ManaType, int>
{
    #region Constructors
    public ManaValueDictionary()
    {
        firsts = new List<ManaType>();
        seconds = new List<int>();
    }

    public ManaValueDictionary(TwinnedList<ManaType, int> twinList)
    {
        firsts = new List<ManaType>(twinList.FirstValues);
        seconds = new List<int>(twinList.SecondValues);
    }
    public ManaValueDictionary(IList<ManaType> firstList, IList<int> secondList)
    {
        firsts = new List<ManaType>(firstList);
        seconds = new List<int>(secondList);
    }
    #endregion

    public int this[ManaType type]
    {
        get
        {
            return SecondValues[FirstValues.IndexOf(type)];
        }
    }

    public void Add(ManaType type)
    {
        if(!Contains(type))
            Add(type, 0);
    }
    public new void Add(ManaType type, int amount)
    {
        if (!Contains(type))
            base.Add(type, amount);
        else
        {
            ModifyAmount(type, amount);
        }
    }
    public void Add(ManaValueDictionary list)
    {
        foreach (ManaType type in list.FirstValues)
        {
            Add(type, list[type]);
        }
    }
    public ManaType GetFirstMana()
    {
        return FirstValues[0];
    }
    public void ModifyAmount(ManaType type, int amount)
    {
        SecondValues[FirstValues.IndexOf(type)] += amount;
    }
    
}

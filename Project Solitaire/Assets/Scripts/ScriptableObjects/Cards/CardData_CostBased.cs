using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Act", menuName = ("Card/Act"))]
public class CardData_CostBased : CardData
{
    [SerializeField] List<ManaType> manaTypes = new List<ManaType>();
    [SerializeField] List<int> manaCosts = new List<int>();

    public int Cost 
    { get 
        {
            int cost = 0;
            foreach (int amount in manaCosts)
                cost += amount;
            return cost; 
        } 
    }
}

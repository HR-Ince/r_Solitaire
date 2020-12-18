using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveData_Commander : LiveCardData
{
    [HideInInspector]
    public CardData_Commander card;

    public void ModifyRank(int amount)
    {
        card.Rank += amount;
    }

    public void ModifyContribution(ManaType type, int amount)
    {
        card.Contribution.Add(type, amount);
    }
}

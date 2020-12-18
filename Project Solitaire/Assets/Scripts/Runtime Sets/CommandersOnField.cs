using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set of Commanders on Field", menuName = "Runtime Set/Set of Commanders on Field")]
public class CommandersOnField : ScriptableObject
{
    private List<CardData_Commander> primary = new List<CardData_Commander>();
    private List<CardData_Commander> secondary = new List<CardData_Commander>();

    public int highestRank { get; private set; } = 0;

    public void Add(LiveCardData card)
    {
        if (card.CurrentRank > highestRank)
            highestRank = card.CurrentRank;
    }
}

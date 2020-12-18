using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "Set/Deck")]
public class Deck : ScriptableObject
{
    public List<CardData> deck = new List<CardData>();
}

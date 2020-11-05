using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<SO_Unit> currentDeck { get; private set; } = new List<SO_Unit>();

    private PlayerController player;
    private SO_Unit[] playerDeck = null;
    

    public void CreateDeck()
    {
        player = GetComponentInParent<PlayerController>();
        playerDeck = player.Deck;
        foreach(SO_Unit unit in playerDeck)
        {
            currentDeck.Add(unit);
        }

        if (currentDeck.Count <= 0)
        {
            Debug.LogError("Deck is empty");
        }
    }

    public void ShuffleDeck()
    {
        List<SO_Unit> shuffledDeck = new List<SO_Unit>();

        foreach(SO_Unit unit in currentDeck)
        {
            int newCardIndex = UnityEngine.Random.Range(0, currentDeck.Count);
            shuffledDeck.Insert(newCardIndex, unit);
        }
    }
}

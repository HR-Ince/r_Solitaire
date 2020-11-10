using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Unit> currentDeck { get; private set; } = new List<Unit>();

    private PlayerController player;
    private Unit[] playerDeck = null;
    

    public void CreateDeck()
    {
        player = GetComponentInParent<PlayerController>();
        playerDeck = player.Deck;
        foreach(Unit unit in playerDeck)
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
        List<Unit> shuffledDeck = new List<Unit>();

        foreach(Unit unit in currentDeck)
        {
            int newCardIndex = UnityEngine.Random.Range(0, currentDeck.Count);
            shuffledDeck.Insert(newCardIndex, unit);
        }
    }
}

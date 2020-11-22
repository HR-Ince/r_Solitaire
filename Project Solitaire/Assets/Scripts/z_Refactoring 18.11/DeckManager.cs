using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private Deck deck;

    public List<CardData> liveDeck = new List<CardData>();

    private void Awake()
    {
        Debug.Log("Deck deck count: " + deck.deck.Count);
        foreach(CardData card in deck.deck)
        {
            liveDeck.Add(card);
            Debug.Log("Card added");
        }
        Debug.Log("Live deck count: " + liveDeck.Count);
    }

    public CardData DrawCard()
    {
        if(liveDeck.Count <= 0) { Debug.Log("Deck is empty"); return null; }

        CardData card = liveDeck[0];
        liveDeck.RemoveAt(0);
        return card;
    }
}

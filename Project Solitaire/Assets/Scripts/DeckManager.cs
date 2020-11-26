using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private Deck deck = null;
    [SerializeField] private CardDataVariable cardData = null;

    public List<CardData> liveDeck = new List<CardData>();

    private void Awake()
    {
        foreach(CardData card in deck.deck)
        {
            liveDeck.Add(card);
        }
    }

    public void DrawCard()
    {
        if(liveDeck.Count <= 0) { Debug.Log("Deck is empty"); return; }

        CardData card = liveDeck[0];
        liveDeck.RemoveAt(0);
        cardData.value = card;
    }
}

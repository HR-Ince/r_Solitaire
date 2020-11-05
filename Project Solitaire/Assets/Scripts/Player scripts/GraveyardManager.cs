using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardManager : MonoBehaviour
{
    public List<SO_Unit> deadThings = new List<SO_Unit>();

    private ObjectHandler objectHandler;

    private PlayerController player;
    private HandManager hand;
    private BoardManager board;

    private void Start()
    {
        objectHandler = FindObjectOfType<ObjectHandler>();

        player = GetComponentInParent<PlayerController>();

        board = player.Board;
        hand = player.Hand;
    }

    public void AddToGraveyard(SO_Unit unit)
    {
        deadThings.Add(unit);
    }

    public bool isDead(SO_Unit unit)
    {
        return deadThings.Contains(unit);
    }

    public void ResurrectAsCard(SO_Unit unit)
    {
        objectHandler.CreateCard(player, unit);
    }

    public void ResurrectAsCounter(SO_Unit unit)
    {
        objectHandler.CreateCounter(player, unit);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardManager : MonoBehaviour
{
    public List<Unit> deadThings = new List<Unit>();

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

    public void AddToGraveyard(Unit unit)
    {
        deadThings.Add(unit);
    }

    public bool isDead(Unit unit)
    {
        return deadThings.Contains(unit);
    }

    public void ResurrectAsCard(Unit unit)
    {
        objectHandler.CreateCard(player, unit);
    }

    public void ResurrectAsCounter(Unit unit)
    {
        objectHandler.CreateCounter(player, unit);
    }
}

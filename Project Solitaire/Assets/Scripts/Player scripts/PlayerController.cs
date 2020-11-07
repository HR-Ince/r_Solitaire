using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool commanderPlayedThisTurn = false;
    public TurnManager.TurnPhase TurnPhase { get; private set; }

    [SerializeField] int LifepointTotal = 20;

    [SerializeField] private SO_Unit[] _deck = null;
    public SO_Unit[] Deck
    {
        get { return _deck; }
        private set { _deck = value; }
    }

    private int currentLifepoints;
    private int totalMana = 0;
    private int currentMana = 0;

    //Dependants
    public BoardManager Board { get; private set; }
    public Camera Cam { get; private set; }
    public DeckManager DeckManager { get; private set; }
    public HandManager Hand { get; private set; }
    public GraveyardManager Graveyard { get; private set; }

    public PlayerController Opponent { get; private set; }

    //Independants
    public PlayerDisplay Display { get; private set; }

    private ObjectHandler objectHandler;
    

    public void SetupPointers()
    {
        Display = FindObjectOfType<PlayerDisplay>();
        objectHandler = FindObjectOfType<ObjectHandler>();

        Board = GetComponentInChildren<BoardManager>();
        Cam = GetComponentInChildren<Camera>();
        DeckManager = GetComponentInChildren<DeckManager>();
        Graveyard = GetComponentInChildren<GraveyardManager>();
        Hand = GetComponentInChildren<HandManager>();
        
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach(PlayerController player in players)
        {
            if (player != this)
            {
                Opponent = player;
            }
        }
    }

    public void SetTurnPhase(TurnManager.TurnPhase phase)
    {
        TurnPhase = phase;
    }

    public void ResetForTurn()
    {
        // Counter resets
        foreach(UnitCounter counter in Board.GetCountersOnBoard())
        {
            counter.ResetForTurn();
        }

        // Card resets
        commanderPlayedThisTurn = false;
    }

    public void DrawCard()
    {
        objectHandler.CreateCard(this, DeckManager.currentDeck[Random.Range(0, DeckManager.currentDeck.Count)]);
    }

    public void TakeLifepointDamage(int damage)
    {
        currentLifepoints -= damage;
    }

    public void SetManaDisplay()
    {
        currentMana = totalMana;
        Display.UpdateManaDisplay(currentMana, totalMana);
    }

    public void IncreaseManaBy(int amount)
    {
        totalMana += amount;
        currentMana += amount;
        Display.UpdateManaDisplay(currentMana, totalMana);
    }

    public bool ManaCostIsAffordable(int cost)
    {
        return cost <= currentMana;
    }

    public void SpendMana(int amount)
    {
        currentMana -= amount;
        Display.UpdateCurrentManaText(currentMana);
    }
}

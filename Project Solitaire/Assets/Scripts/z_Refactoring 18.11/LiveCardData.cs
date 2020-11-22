using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiveCardData : MonoBehaviour
{
    [SerializeField] DeckManager deck = null;
    [SerializeField] PlayerHand playerHand = null;


    [Min(0)] private int currentAtk;
    public int CurrentAtk { get { return currentAtk; } }
    [Min(0)] private int currentDef;
    public int CurrentDef { get { return currentDef; } }
    [Min(0)] private int currentCost;
    public int CurrentCost { get { return currentCost; } }
    [Min(0)] private int currentRank;
    public int CurrentRank { get { return currentRank; } }
    [Min(0)] private int currentContribution;
    public int CurrentContribution { get { return currentContribution; } }

    public CardData Card { get; private set; }
    public UnityEvent afterSetup;

    private void Start()
    {
        Card = deck.DrawCard();
        AssignVariablesViaCast();
        if (afterSetup != null)
            afterSetup.Invoke();
    }

    public void SetCardData(CardData data)
    {
        Card = data;
    }

    private void AssignVariablesViaCast()
    {
        if (Card is CardData_Commander commander)
        {
            currentRank = commander.Rank;
            currentContribution = commander.Contribution;
        }
        else if (Card is CardData_CostBased i)
            currentCost = i.Cost;

        if (Card is CardData_Unit unit)
        {
            currentAtk = unit.Atk;
            currentDef = unit.Def;
        }
    }

    public void ModifyAtk(int amount)
    {
        currentAtk += amount;
    }

    public void ModifyDef(int amount)
    {
        currentDef += amount;
    }

    public void ModifyCost(int amount)
    {
        currentCost += amount;
    }

    public void ModifyRank(int amount)
    {
        currentRank += amount;
    }

    public void ModifyContribution(int amount)
    {
        currentContribution += amount;
    }
}

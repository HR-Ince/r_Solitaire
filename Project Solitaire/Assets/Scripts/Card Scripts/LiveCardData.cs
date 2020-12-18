using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiveCardData : MonoBehaviour
{
    [SerializeField] LiveManaValues totalMana = null;
    [SerializeField] CommandersOnField commanders = null;
    [SerializeField] CardData testCard = null;
    public UnityEvent OnValueChange;

    public CardData Card { get; private set; }
    [Min(0)] private int currentAtk;
    public int CurrentAtk { get { return currentAtk; } }
    [Min(0)] private int currentDef;
    public int CurrentDef { get { return currentDef; } }
    [Min(0)] private int currentRank;
    public int CurrentRank { get { return currentRank; } }
    public ManaValueDictionary currentCost { get; private set; }
    public ManaValueDictionary currentContribution { get; private set; }
    
    public bool IsPlayable { get; private set; }

    private void Awake()
    {
        if (testCard != null)
            Card = testCard;
        AssignVariablesViaCast();
    }

    public void SetCardData(CardData data)
    {
        Card = data;
        AssignVariablesViaCast();
    }

    private void AssignVariablesViaCast()
    {
        if (Card is CardData_Commander commander)
        {
            currentRank = commander.Rank;
            currentContribution = commander.Contribution;
        }
        else if (Card is CardData_CostBased card)
            currentCost = new ManaValueDictionary(card.manaCost);

        if (Card is CardData_Unit unit)
        {
            currentAtk = unit.Atk;
            currentDef = unit.Def;
        }
    }

    public void ModifyAtk(int amount)
    {
        currentAtk += amount;
        if (OnValueChange != null)
            OnValueChange.Invoke();
    }

    public void ModifyDef(int amount)
    {
        currentDef += amount;
        if (OnValueChange != null)
            OnValueChange.Invoke();
    }

    public void ModifyCost(ManaType type, int amount)
    {
        currentCost.Add(type, amount);
        if (OnValueChange != null)
            OnValueChange.Invoke();
    }

    public void GetIsCardPlayable()
    {
        if (Card is CardData_CostBased)
        {
            foreach (ManaType type in currentCost.FirstValues)
            {
                if (currentCost[type] > totalMana.list[type])
                    IsPlayable = false;
                else
                    IsPlayable = true;
            }
        }
        else if(Card is CardData_Commander)
        {
            if (currentRank - 1 <= commanders.highestRank)
                IsPlayable = true;
            else
                IsPlayable = false;
        }
    }
}

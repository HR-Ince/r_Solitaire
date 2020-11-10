using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicUIElements : MonoBehaviour
{
    [HideInInspector]
    public Display display;
    [HideInInspector]
    public int baseHealth;
    public int currentHealth { get; private set; }

    [HideInInspector]
    public int baseAtk;
    public int currentAtk { get; private set; }
    [HideInInspector]
    public int baseCost;
    public int currentCost { get; private set; }

    [HideInInspector]
    public int baseMana;
    public int currentMana { get; private set; }
    
    public void SetStatsToBase()
    {
        currentHealth = baseHealth;
        currentMana = baseMana;
        currentAtk = baseAtk;
        currentCost = baseCost;

        Display();
    }

    private void Display()
    {
        if (!display) { Debug.LogError("No display script on " + name); return; }
        display.DisplayDynamicElements(this);
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth < 0)
            currentHealth = 0;

        Display();
    }

    public void ModifyAtk(int amount)
    {
        currentAtk += amount;
        if (currentAtk < 0)
            currentAtk = 0;

        Display();
    }

    public void ModifyMana(int amount)
    {
        baseMana += amount;
        if (baseMana < 0)
            baseMana = 0;
        currentMana += amount;
        if (currentMana < 0)
            currentMana = 0;

        Display();
    }

    public void SpendMana(int amount)
    {
        currentMana -= amount;
        if (currentMana < 0)
            currentMana = 0;

        Display();
    }

    public void ModifyCost(int amount)
    {
        currentCost += amount;
        if (currentCost < 0)
            currentCost = 0;

        Display();
    }
}

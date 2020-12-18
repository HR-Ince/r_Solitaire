using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Act", menuName = ("Card/Act"))]
public class CardData_CostBased : CardData
{
    [Header("Mana Cost (Sizes must match)")]
    [SerializeField] protected List<ManaType> costTypes = new List<ManaType>();
    [SerializeField] protected List<int> costAmounts = new List<int>();
    
    public ManaValueDictionary manaCost;

    public void Construct(CardData_CostBased data)
    {
        cardImage = data.cardImage;
        cardName = data.cardName;
        cardTypes = data.cardTypes;
        costTypes = data.costTypes;
        costAmounts = data.costAmounts;
    }

    private void OnEnable()
    {
        ConstructManaCost();
    }
    protected void ConstructManaCost()
    {
        manaCost = new ManaValueDictionary(costTypes, costAmounts);
    }


    public void Construct(string name, Sprite image, string[] types, List<ManaType> manaTypes, List<int> costAmounts)
    {
        cardName = name;
        cardImage = image;
        cardTypes = types;

        costTypes = manaTypes;
        this.costAmounts = costAmounts;
    }
}

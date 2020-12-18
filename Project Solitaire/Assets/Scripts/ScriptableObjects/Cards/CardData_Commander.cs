using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Commander", menuName = ("Card/Commander"))]
public class CardData_Commander : CardData
{
    [SerializeField] protected int rank;
    [Header("Contribution")]
    [SerializeField] protected List<ManaType> contributionTypes = null;
    [SerializeField] protected List<int> contributionAmounts = null;

    public CardData_Commander() { }

    public ManaValueDictionary Contribution { get; private set; }

    public int Rank { get { return rank; } set { rank = value; } }

    public void Construct(CardData_Commander commander)
    {
        cardName = commander.cardName;
        cardImage = commander.cardImage;
        cardTypes = commander.cardTypes;
        rank = commander.rank;
        contributionTypes = commander.contributionTypes;
        contributionAmounts = commander.contributionAmounts;

        ConstructContribution();
    }

    public void Construct(string name, Sprite image, string[] types, int rank, List<ManaType> manaTypes, List<int> amounts)
    {
        cardName = name;
        cardImage = image;
        cardTypes = types;
        this.rank = rank;
        contributionTypes = manaTypes;
        contributionAmounts = amounts;

        ConstructContribution();
    }

    private void ConstructContribution()
    {
        if(contributionTypes == null || contributionAmounts == null)
        { Debug.LogError("Contribution error on" + CardName); return; }

        Contribution = new ManaValueDictionary(contributionTypes, contributionAmounts);
    }
}

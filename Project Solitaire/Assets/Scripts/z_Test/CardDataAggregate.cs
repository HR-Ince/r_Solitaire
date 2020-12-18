using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataAggregate : ScriptableObject
{
    [SerializeField] private string cardName = "";
    [SerializeField] private Sprite cardImage = null;
    [SerializeField] private string[] cardTypes = new string[3];

    public bool isAttackerDefender = false;
    [SerializeField] private int atk = 0;
    [SerializeField] private int def = 0;

    [SerializeField] List<CardCostType> costTypes = new List<CardCostType>();
    [SerializeField] private CardCostType costType;

    public void Construct(string name, Sprite image, string[] types)
    {
        cardName = name;
        cardImage = image;
        cardTypes = types;
    }
    public void Construct(string name, Sprite image, string[] types, CardCostType cost)
    {
        cardName = name;
        cardImage = image;
        cardTypes = types;
        costType = cost;
    }
    public void Construct(string name, Sprite image, string[] types, CardCostType cost, int atk, int def)
    {
        cardName = name;
        cardImage = image;
        cardTypes = types;
        costType = cost;
        isAttackerDefender = true;
        this.atk = atk;
        this.def = def;
    }

    #region Public Getters
    public string CardName { get { return cardName; } }
    public Sprite CardImage { get { return cardImage; } }
    public string[] CardTypes { get { return cardTypes; } }
    public int Atk { get { return atk; } }
    public int Def { get { return def; } }
    public CardCostType CostType { get { return costType; } }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = ("Card/Unit"))]
public class CardData_Unit : CardData_CostBased
{
    [SerializeField] protected int atk;
    [SerializeField] protected int def;

    public int Atk { get { return atk; } set { atk = value; } }
    public int Def { get { return def; } set { def = value; } }

    public void Construct(CardData_Unit data)
    {
        cardImage = data.cardImage;
        cardName = data.cardName;
        cardTypes = data.cardTypes;
        atk = data.atk;
        def = data.def;
    }

    public void Construct(string name, Sprite image, string[] types, List<ManaType> manaTypes, List<int> amounts, int atk, int def)
    {
        cardImage = image;
        cardName = name;
        cardTypes = types;
        costTypes = manaTypes;
        costAmounts = amounts;
        this.atk = atk;
        this.def = def;
    }
}

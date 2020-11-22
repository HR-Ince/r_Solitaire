using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Act", menuName = ("Card/Act"))]
public class CardData_CostBased : CardData
{
    [SerializeField] protected int cost;

    public int Cost { get { return cost; } set { cost = value; } }
}

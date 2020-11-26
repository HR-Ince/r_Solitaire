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

}

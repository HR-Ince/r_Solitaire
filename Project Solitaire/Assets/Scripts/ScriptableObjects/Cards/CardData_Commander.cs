using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Commander", menuName = ("Card/Commander"))]
public class CardData_Commander : CardData
{
    [SerializeField] protected int rank;
    [SerializeField] protected int contribution;

    public int Rank { get { return rank; } set { rank = value; } }
    public int Contribution { get { return contribution; } set { contribution = value; } }
}

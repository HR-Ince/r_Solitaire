using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Commander", menuName = "Units/Commander")]
public class CommanderUnit : SO_Unit
{
    [SerializeField] private int _rank = 0;
    public int rank { get { return _rank; } private set { _rank = value; } }

    [SerializeField] private int _manaContribution = 0;
    public int manaContribution { get { return _manaContribution; } private set { _manaContribution = value; } }
}

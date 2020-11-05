using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Unit", menuName = "Units/Basic Unit")]
public class BasicUnit : SO_Unit
{
    [SerializeField] private int _cost = 0;
    public int cost { get { return _cost; } private set { _cost = value; } }
}

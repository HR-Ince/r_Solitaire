using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] CardDataAggregate data;

    public CardDataAggregate Data { get { return data; } }
}

using System;
using UnityEngine;

public abstract class CardData : ScriptableObject
{
    [SerializeField] protected string cardName;
    [SerializeField] protected Sprite cardImage;
    [SerializeField] protected string[] cardTypes = new string[3];
    //[SerializeField] protected Effect cardEffect;

    public string CardName { get { return cardName; } }
    public Sprite CardImage { get { return cardImage; } }
    public string[] CardTypes { get { return cardTypes; } }
    //public bool IsEffectCard { get { return cardEffect != null; } }
    //public Effect CardEffect { get { return cardEffect; } }
}

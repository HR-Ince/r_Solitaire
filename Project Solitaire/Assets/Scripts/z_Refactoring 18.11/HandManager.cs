using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] GameObject cardBase;
    [SerializeField] ListOfObjsInHand handObjs;

    private RuntimeSet<CardData> hand;

    public void AddCardToHand(CardData card)
    {
        hand.Add(card);
        var obj = Instantiate(cardBase);
        handObjs.objs.Add(obj);
        obj.TryGetComponent(out LiveCardData liveData);
    }
}

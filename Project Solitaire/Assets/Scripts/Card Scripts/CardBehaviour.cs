using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerHand hand = null;
    [SerializeField] private UnityEvent OnCreation = null;

    private void Start()
    {
        hand.AddCardToHand(gameObject);
        if (OnCreation != null)
            OnCreation.Invoke();
    }
}

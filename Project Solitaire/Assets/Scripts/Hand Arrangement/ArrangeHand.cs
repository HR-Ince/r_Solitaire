using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArrangeHand : MonoBehaviour
{
    [SerializeField] protected PlayerHand handDataList;
    [SerializeField] protected RectTransform handRectTransform;

    // To access dimensions
    public GameObject cardSample = null;

    public float snapToHandDistance = 0f;

    public float xCardSpacing = 10f;

    protected float cardWidth;
    protected float maximumHandWidth;
    
    protected void Awake()
    {
        maximumHandWidth = handRectTransform.rect.width;

        cardWidth = cardSample.GetComponent<RectTransform>().rect.width;
    }

    public virtual void ArrangeCards() { }
}

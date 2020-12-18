using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrangeHandInFan : ArrangeHand
{
    [SerializeField] float cardFanAngle = 50f;
    [SerializeField] float yCardBuffer = 1.2f;

    public override void ArrangeCards()
    {
        int handSize = handDataList.list.Count;

        float rangeMid = handSize / 2f - 0.5f;

        float anglePerCard = cardFanAngle / handSize;

        float leftmostEdge = ((0 - rangeMid) * xCardSpacing) - (cardWidth / 2);
        float rightmostEdge = ((handSize - (1 + rangeMid)) * xCardSpacing) + (cardWidth / 2);

        float newX = 0f;

        if((rightmostEdge - leftmostEdge) < maximumHandWidth)
        {
            for (int i = 0; i < handSize; i++)
            {
                float indexMidDiff = (i - rangeMid);

                // X Arrangement
                newX = indexMidDiff * xCardSpacing;
            }
        }
        else
        {
            var constrainedSpacing = maximumHandWidth / handSize;

            for(int i = 0; i < handSize; i++)
            {
                float indexMidDiff = i - rangeMid;

                newX = indexMidDiff * constrainedSpacing;
            }
        }

        for(int i = 0; i < handSize; i++)
        {
            float indexMidDiff = (i - rangeMid);

            // Y Arrangement
            float newY = Mathf.Abs(indexMidDiff * yCardBuffer);

            if (i < rangeMid)
            {
                newY = Mathf.Floor(i - rangeMid) * yCardBuffer;
            }
            else if (i > rangeMid)
            {
                newY = Mathf.Ceil(i - rangeMid) * -yCardBuffer;
            }

            // Z Angle
            float zAngle = -(indexMidDiff * anglePerCard);


            handDataList.list[i].transform.SetSiblingIndex(i);

            var rectTransform = handDataList.list[i].GetComponent<RectTransform>();

            rectTransform.anchoredPosition = handRectTransform.anchoredPosition + new Vector2(newX, newY);
            rectTransform.rotation = Quaternion.Euler(0f, 0f, zAngle);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrangeHandInRow : ArrangeHand
{
    public override void ArrangeCards()
    {
        int handSize = handDataList.list.Count;

        float rangeMid = handSize / 2f - 0.5f;

        float leftmostEdge = ((0 - rangeMid) * xCardSpacing) - (cardWidth / 2);
        float rightmostEdge = ((handSize - (1 + rangeMid)) * xCardSpacing) + (cardWidth / 2);

        if((rightmostEdge - leftmostEdge) <= maximumHandWidth)
        {
            for (int i = 0; i < handSize; i++)
            {
                handDataList.list[i].transform.SetSiblingIndex(i);

                float newX = (i - rangeMid) * xCardSpacing;

                var rectTransform = handDataList.list[i].GetComponent<RectTransform>();
                rectTransform.anchoredPosition = handRectTransform.anchoredPosition + new Vector2(newX, 0f);
            }
        }
        else
        {
            var constrainedSpacing = (maximumHandWidth - cardWidth) / handSize;

            for (int i = 0; i < handSize; i++)
            {
                handDataList.list[i].transform.SetSiblingIndex(i);

                var rectTransform = handDataList.list[i].GetComponent<RectTransform>();

                float newX = (i - rangeMid) * constrainedSpacing;

                rectTransform.anchoredPosition = handRectTransform.anchoredPosition + new Vector2(newX, 0f);
            }
        }
    }
}

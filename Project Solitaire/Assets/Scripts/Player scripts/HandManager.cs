using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] Card3D cardBase;

    [SerializeField] float xCardSpacing = 0.8f;
    [SerializeField] float zCardSpacing = 0.1f;
    [SerializeField] float yCardBuffer = 1.2f;
    [SerializeField] float cardFanAngle = 10f;

    List<Card3D> cardsInHand = new List<Card3D>();

    public void AddCardToHand(Card3D card)
    {
        cardsInHand.Add(card);
        ArrangeCards();
    }

    public void RemoveCardFromHand(Card3D card)
    {
        cardsInHand.Remove(card);
        ArrangeCards();
    }

    private void ArrangeCards()
    {
        float rangeMid = cardsInHand.Count / 2f - 0.5f;

        float anglePerCard = cardFanAngle / cardsInHand.Count;

        for (int i = 0; i < cardsInHand.Count; i++)
        {
            float indexMidDiff = (i - rangeMid);
            float newX = indexMidDiff * xCardSpacing;

            float newY = Mathf.Abs(indexMidDiff * yCardBuffer);

            if (i < rangeMid)
            {
                newY = Mathf.Floor(i - rangeMid) * yCardBuffer;
            }
            else if (i > rangeMid)
            {
                newY = Mathf.Ceil(i - rangeMid) * -yCardBuffer;
            }

            float newZ = indexMidDiff * -zCardSpacing;

            float zAngle = -(indexMidDiff * anglePerCard);

            cardsInHand[i].transform.localPosition = new Vector3(newX, newY, newZ);
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, zAngle);
        }
    }
}

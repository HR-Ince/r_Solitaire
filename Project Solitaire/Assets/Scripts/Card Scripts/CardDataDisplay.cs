using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDataDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private Image image = null;
    [SerializeField] private TMP_Text typeText = null;
    [SerializeField] private TMP_Text costText = null;
    [SerializeField] private TMP_Text rankText = null;
    [SerializeField] private TMP_Text contributionText = null;
    [SerializeField] private TMP_Text descriptionText = null;
    [SerializeField] private TMP_Text atkText = null;
    [SerializeField] private TMP_Text defText = null;
    
    private CardData cardData;
    private LiveCardData liveData;

    private void Start()
    {
        liveData = GetComponent<LiveCardData>();
        cardData = liveData.Card;

        DisplayGenericData(cardData);

        if (cardData is CardData_Commander)
            DisplayCommanderData();
        else if (cardData is CardData_Unit)
            DisplayUnitData();
        else if (cardData is CardData_CostBased)
            DisplayCostBasedData();
    }

    private void DisplayGenericData(CardData card)
    {
        if(nameText != null)
            nameText.text = card.CardName;
        if(image != null)
            image.sprite = card.CardImage;
        if(typeText != null)
        {
            string type = cardData.CardTypes[0];
            if (cardData.CardTypes[1] != null)
                type += " " + cardData.CardTypes[1];
            if (cardData.CardTypes[2] != null)
                type += " -- " + cardData.CardTypes[2];

            typeText.text = type;
        }
        if(descriptionText != null)
        {
            //Description text setup goes here
        }
    }

    private void DisplayCommanderData()
    {
        if(contributionText != null)
        {
            int contribution = liveData.CurrentContribution;
            contributionText.text = contribution.ToString();
        }
            
        if(rankText != null)
        {
            int rank = liveData.CurrentRank;
            rankText.text = rank.ToString();
        }

        atkText.enabled = false;
            
    }

    private void DisplayUnitData()
    {
        if (costText != null)
        {
            int cost = liveData.CurrentCost;
            costText.text = cost.ToString();
        }
        if (atkText != null)
        {
            int atk = liveData.CurrentAtk;
            atkText.text = atk.ToString();
        }
            
        if(defText != null)
        {
            int def = liveData.CurrentDef;
            defText.text = def.ToString();
        }
            
    }

    private void DisplayCostBasedData()
    {
        if (costText != null)
        {
            int cost = liveData.CurrentCost;
            costText.text = cost.ToString();
        }

        atkText.enabled = false;
        defText.enabled = false;
    }
}

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

    private void Awake()
    {
        liveData = GetComponent<LiveCardData>();
        cardData = liveData.Card;
    }

    private void Start()
    {
        DisplayGenericData(cardData);

        if (cardData is CardData_Commander commander)
            DisplayCommanderData(commander);
        else if (cardData is CardData_Unit unit)
            DisplayUnitData(unit);
        else if (cardData is CardData_CostBased act)
            DisplayCostBasedData(act);
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
    }

    private void DisplayCommanderData(CardData_Commander card)
    {
        if(contributionText != null)
        {
            int contribution = card.Contribution + liveData.CurrentContribution;
            contributionText.text = contribution.ToString();
        }
            
        if(rankText != null)
        {
            int rank = card.Rank + liveData.CurrentRank;
            rankText.text = rank.ToString();
        }

        atkText.enabled = false;
            
    }

    private void DisplayUnitData(CardData_Unit card)
    {
        if (costText != null)
        {
            int cost = card.Cost + liveData.CurrentCost;
            costText.text = cost.ToString();
        }
        if (atkText != null)
        {
            int atk = card.Atk + liveData.CurrentAtk;
            atkText.text = atk.ToString();
        }
            
        if(defText != null)
        {
            int def = card.Def + liveData.CurrentDef;
            defText.text = def.ToString();
        }
            
    }

    private void DisplayCostBasedData(CardData_CostBased card)
    {
        if (costText != null)
        {
            int cost = card.Cost + liveData.CurrentCost;
            costText.text = cost.ToString();
        }

        atkText.enabled = false;
        defText.enabled = false;
    }
}

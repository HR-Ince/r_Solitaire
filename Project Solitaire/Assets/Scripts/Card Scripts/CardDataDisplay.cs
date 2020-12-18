using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDataDisplay : MonoBehaviour
{
    [SerializeField] protected CardDisplayLibrary display;
    protected CardData generics;
    protected LiveCardData liveData;

    private void Start()
    {
        liveData = GetComponent<LiveCardData>();
        generics = liveData.Card;

        DisplayData();
    }

    private void DisplayData()
    {
        DisplayGenericData();
        DisplayLiveData();
    }

    private void DisplayGenericData()
    {
        display.nameText.text = generics.CardName;
        display.image.sprite = generics.CardImage;
        if(display.typeText != null)
        {
            string type = generics.CardTypes[0];
            if (generics.CardTypes[1] != null)
                type += " " + generics.CardTypes[1];
            if (generics.CardTypes[2] != null)
                type += " -- " + generics.CardTypes[2];

            display.typeText.text = type;
        }
    }

    public void DisplayLiveData()
    {
        if (generics is CardData_Commander commander)
            DisplayCommanderData(commander);
        else if (generics is CardData_CostBased costly)
            DisplayCostBasedData(costly);
        if (generics is CardData_Unit unit)
            DisplayUnitData(unit);
    }

    private void DisplayCommanderData(CardData_Commander card)
    {
        if (display.contributionImages.Count < liveData.currentContribution.Count)
        { Debug.LogError("Insufficient Contribution containers on card"); }
        else
        {
            for (int i = 0; i < liveData.currentContribution.Count; i++)
            {
                display.contributionImages[i].gameObject.SetActive(true);
                display.contributionImages[i].sprite = liveData.currentContribution.FirstValues[i].manaDepictionSprite;
                display.contributionTexts[i].gameObject.SetActive(true);
                display.contributionTexts[i].text = liveData.currentContribution.SecondValues[i].ToString();
            }
        }

        if (display.rankText != null)
        {
            display.rankText.transform.parent.gameObject.SetActive(true);
            display.rankText.gameObject.SetActive(true);
            display.rankText.text = liveData.CurrentRank.ToString();
        }

        display.atkText.enabled = false;
        display.defText.enabled = false;
    }

    private void DisplayCostBasedData(CardData_CostBased card)
    {
        if (display.costImages.Count < liveData.currentCost.Count || display.costTexts.Count < liveData.currentCost.Count)
        { Debug.LogError("Insufficent containers for cost data on card"); }
        else
        {

            for (int i = 0; i < liveData.currentCost.Count; i++)
            {
                display.costImages[i].gameObject.SetActive(true);
                display.costImages[i].sprite = liveData.currentCost.FirstValues[i].manaDepictionSprite;

                display.costTexts[i].gameObject.SetActive(true);
                display.costTexts[i].text = liveData.currentCost.SecondValues[i].ToString();
            }
        }
    }

    private void DisplayUnitData(CardData_Unit card)
    {
        if (display.atkText != null)
        {
            display.atkText.gameObject.SetActive(true);
            display.atkText.text = liveData.CurrentAtk.ToString();
        }
            
        if(display.defText != null)
        {
            display.defText.gameObject.SetActive(true);
            display.defText.text = liveData.CurrentDef.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDataDisplay3D : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private SpriteRenderer image = null;
    [SerializeField] private TMP_Text typeText = null;
    [SerializeField] private List<SpriteRenderer> costImages = new List<SpriteRenderer>();
    [SerializeField] private List<TMP_Text> costTexts = new List<TMP_Text>();
    [SerializeField] private TMP_Text rankText = null;
    [SerializeField] private List<SpriteRenderer> contributionImages = null;
    [SerializeField] private List<TMP_Text> contributionTexts = null;
    [SerializeField] private TMP_Text descriptionText = null;
    [SerializeField] private TMP_Text atkText = null;
    [SerializeField] private TMP_Text defText = null;

    private CardData generics;
    private LiveCardData liveData;

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

    public void DisplayLiveData()
    {
        if (generics is CardData_Commander)
            DisplayCommanderData();
        else if (generics is CardData_CostBased)
        {
            DisplayCostBasedData();
            if (generics is CardData_Unit)
                DisplayUnitData();
        }

    }

    private void DisplayGenericData()
    {
        if (nameText != null)
            nameText.text = generics.CardName;
        if (image != null)
            image.sprite = generics.CardImage;
        if (typeText != null)
        {
            string type = generics.CardTypes[0];
            if (generics.CardTypes[1] != null)
                type += " " + generics.CardTypes[1];
            if (generics.CardTypes[2] != null)
                type += " -- " + generics.CardTypes[2];

            typeText.text = type;
        }
        if (descriptionText != null)
        {
            //Description text setup goes here
        }
    }

    private void DisplayCommanderData()
    {
        if (contributionTexts.Count < liveData.currentContribution.Count || contributionImages.Count < liveData.currentContribution.Count)
        { Debug.LogError("Insufficient Contribution containers on card"); }
        else
        {
            for (int i = 0; i < liveData.currentContribution.Count; i++)
            {
                contributionImages[i].gameObject.SetActive(true);
                contributionImages[i].sprite = liveData.currentContribution.FirstValues[i].manaDepictionSprite;

                contributionTexts[i].gameObject.SetActive(true);
                contributionTexts[i].text = liveData.currentContribution.SecondValues[i].ToString();
            }
        }

        if (rankText != null)
        {
            rankText.transform.parent.gameObject.SetActive(true);
            rankText.gameObject.SetActive(true);
            rankText.text = liveData.CurrentRank.ToString();
        }

        if(atkText != null)
            atkText.enabled = false;
        if(defText != null)
            defText.enabled = false;
    }


    private void DisplayCostBasedData()
    {
        if (costImages.Count < liveData.currentCost.Count || costTexts.Count < liveData.currentCost.Count)
        { Debug.LogError("Insufficent containers for cost data on card"); }
        else
        {

            for (int i = 0; i < liveData.currentCost.Count; i++)
            {
                costImages[i].gameObject.SetActive(true);
                costImages[i].sprite = liveData.currentCost.FirstValues[i].manaDepictionSprite;

                costTexts[i].gameObject.SetActive(true);
                costTexts[i].text = liveData.currentCost.SecondValues[i].ToString();
            }
        }
    }

    private void DisplayUnitData()
    {
        if (atkText != null)
        {
            atkText.gameObject.SetActive(true);
            atkText.text = liveData.CurrentAtk.ToString();
        }

        if (defText != null)
        {
            defText.gameObject.SetActive(true);
            defText.text = liveData.CurrentDef.ToString();
        }
    }
}

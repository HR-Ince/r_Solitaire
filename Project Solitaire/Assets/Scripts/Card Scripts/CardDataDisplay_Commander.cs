using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CardDataDisplay_Commander : CardDataDisplay
{
    public new void DisplayLiveData() //OVERRIDE
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
}

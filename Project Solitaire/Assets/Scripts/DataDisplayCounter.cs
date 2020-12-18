using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataDisplayCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private SpriteRenderer portrait = null;
    [SerializeField] private TMP_Text rankText = null;
    [SerializeField] private List<GameObject> contributionObjs = null;
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

    public void TempDisplay()
    {
        
    }

    private void DisplayData()
    {
        DisplayGenericData();
        DisplayLiveData();
    }

    public void DisplayLiveData()
    {
        if (generics is CardData_Commander)
        {
            DisplayCommanderData();
        }
        else if (generics is CardData_Unit)
        {
            DisplayUnitData();
        }
    }

    private void DisplayGenericData()
    {
        //portrait.sprite = generics.CardImage;
    }

    private void DisplayCommanderData()
    {
        rankText.text = liveData.CurrentRank.ToString();
        AssignContribution();
    }

    private void AssignContribution()
    {
        if(contributionObjs.Count <= 0) { return; }

        for(int i = 0; i < contributionObjs.Count; i++)
        {
            if (i > liveData.currentContribution.Count - 1)
            {
                contributionObjs[i].SetActive(false);
            }
            else
            {
                contributionObjs[i].SetActive(true);

                contributionObjs[i].GetComponentInChildren<SpriteRenderer>().sprite = liveData.currentContribution.FirstValues[i].manaDepictionSprite;
                contributionObjs[i].GetComponentInChildren<TextMeshPro>().text = liveData.currentContribution.SecondValues[i].ToString();
            }
        }
    }

    private void DisplayUnitData()
    {
        atkText.text = liveData.CurrentAtk.ToString();
        defText.text = liveData.CurrentDef.ToString();
    }
}

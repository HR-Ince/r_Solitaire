using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggregateDataDisplay : MonoBehaviour
{
    [SerializeField] protected CardDisplayLibrary display;
    CardDataAggregate card;

    private void Start()
    {
        card = GetComponent<Card>().Data;

        DisplayData();
    }

    private void DisplayData()
    {
        DisplayGenericData();
        DisplayLiveData();
    }

    private void DisplayGenericData()
    {
        display.nameText.text = card.CardName;
        display.image.sprite = card.CardImage;
        if (display.typeText != null)
        {
            string type = card.CardTypes[0];
            if (card.CardTypes[1] != null)
                type += " " + card.CardTypes[1];
            if (card.CardTypes[2] != null)
                type += " -- " + card.CardTypes[2];

            display.typeText.text = type;
        }
    }

    public void DisplayLiveData()
    {
        if (card.isAttackerDefender)
            DisplayAtkDef();
        else
            display.atkDefHolder.SetActive(false);

        if(card.CostType != null)
        {
            if (card.CostType is CardCost_Mana manaCostContainer)
            {
                DisplayManaCost(manaCostContainer);
                Debug.Log("Display!");
            }
                
        }
    }

    private void DisplayAtkDef()
    {
        display.atkDefHolder.SetActive(true);
        display.atkText.text = card.Atk.ToString();
        display.defText.text = card.Def.ToString();
    }

    private void DisplayManaCost(CardCost_Mana manaCostContainer)
    {
        var manaCost = manaCostContainer.values;
        for(int i = 0; i < manaCost.Count; i++)
        {
            display.costImages[i].gameObject.SetActive(true);
            display.costImages[i].sprite = manaCost.FirstValues[i].manaDepictionSprite;
            display.costTexts[i].gameObject.SetActive(true);
            display.costTexts[i].text = manaCost.SecondValues[i].ToString();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] Image portrait = null;

    [SerializeField] TMP_Text healthText = null;

    [Header("Card/Counter")]
    [SerializeField] TMP_Text atkText = null;

    [Header("Card")]
    [SerializeField] TMP_Text nameText = null;
    [SerializeField] TMP_Text costText = null;
    
    [Header("Player")]
    [SerializeField] TMP_Text manaAvailableText = null;
    [SerializeField] TMP_Text manaTotalText = null;

    public void DisplayStaticElements(Displayable unit)
    {
        // Universal
        if (portrait != null)
        {
            portrait.sprite = unit.portrait;
        }

        //Card
        if (nameText != null)
        {
            nameText.text = unit.name;
        }

    }

    public void DisplayDynamicElements(DynamicUIElements stats)
    {
        // Universal
        if (healthText != null)
        {
            healthText.text = stats.currentHealth.ToString();
        }

        // Card/Counter
        if (atkText != null)
        {
            atkText.text = stats.currentAtk.ToString();
        }

        // Card
        if (costText != null)
        {
            costText.text = stats.currentCost.ToString();
        }

        // Player
        if (manaAvailableText != null)
        {
            manaAvailableText.text = stats.currentMana.ToString();
        }

        if (manaTotalText != null)
        {
            manaTotalText.text = stats.baseMana.ToString();
        }
    }


}



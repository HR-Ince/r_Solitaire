using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplayUGUI : MonoBehaviour
{
    [HideInInspector]
    public bool isCard = false;

    [Header("Universal")]
    [SerializeField] TextMeshProUGUI atkText = null;
    [SerializeField] TextMeshProUGUI defText = null;
    [SerializeField] Selectable effectActivationButton = null;

    [Header("Card")]
    [SerializeField] TextMeshProUGUI nameText = null;
    [SerializeField] TextMeshProUGUI costText = null;

    [Header("Colour")]
    [SerializeField] Color baseColour = Color.clear;
    [SerializeField] Color increasedColour = Color.clear;
    [SerializeField] Color decreasedColour = Color.clear;

    private int baseAtk;
    private int baseDef;
    private string effectText;

    public void Setup(SO_Unit unit)
    {
        baseAtk = unit.Atk;
        atkText.text = unit.Atk.ToString();
        baseDef = unit.Def;
        defText.text = unit.Def.ToString();
        if (unit.Effect != null)
        {
            effectText = unit.effectText;
        }

        if (!isCard)
        {
            GetComponent<MeshRenderer>().material = unit.CounterMaterial;
        }
        else if (isCard)
        {
            nameText.text = unit.UnitName;

            if (unit is BasicUnit basicUnit)
            {
                costText.text = basicUnit.cost.ToString();
            }

            if (unit is CommanderUnit)
            {
                costText.text = null;
            }
        }
    }

    public void UpdateAtkText(int newAtk)
    {
        atkText.text = newAtk.ToString();
        if (newAtk > baseAtk)
        {
            atkText.color = increasedColour;
        }
        else if (newAtk < baseAtk)
        {
            atkText.color = decreasedColour;
        }
        else
        {
            atkText.color = baseColour;
        }
    }

    public void UpdateDefText(int newDef)
    {
        defText.text = newDef.ToString();
        if (newDef > baseDef)
        {
            defText.color = increasedColour;
        }
        else if (newDef < baseDef)
        {
            defText.color = decreasedColour;
        }
        else
        {
            defText.color = baseColour;
        }
    }

    public void DisplayDetail()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] Button effectActivationButton = null;
    [SerializeField] TextMeshProUGUI totalManaText = null;
    [SerializeField] TextMeshProUGUI currentManaText = null;

    private UnitCounter effectUnit;

    public void UpdateManaDisplay(int currentMana, int totalMana)
    {
        UpdateCurrentManaText(currentMana);
        UpdateTotalManaText(totalMana);
    }

    public void UpdateCurrentManaText(int currentMana)
    {
        currentManaText.text = currentMana.ToString();
    }

    public void UpdateTotalManaText(int totalMana)
    {
        totalManaText.text = "/" + totalMana.ToString();
    }

    public void SetUnitForButton(UnitCounter unit)
    {
        effectUnit = unit;
    }

    public void DisplayEffectActivationButtonFor(UnitManifestation unit)
    {
        effectActivationButton.gameObject.SetActive(true);
        if(unit is UnitCounter counter)
        {
            effectActivationButton.onClick.RemoveAllListeners();
            effectActivationButton.onClick.AddListener(counter.ActivateEffect);
        }
    }

    public void HideEffectActivationButton()
    {
        effectActivationButton.onClick.RemoveAllListeners();
        if (!effectActivationButton.gameObject.activeInHierarchy) { return; }
        effectActivationButton.gameObject.SetActive(false);
    }
}

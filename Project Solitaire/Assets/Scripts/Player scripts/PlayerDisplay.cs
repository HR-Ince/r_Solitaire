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

}

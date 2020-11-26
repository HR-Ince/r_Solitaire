using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text lifePointText = null;
    [SerializeField] private Image portrait = null;
    [SerializeField] private TMP_Text currentManaText = null;
    [SerializeField] private TMP_Text totalManaText = null;
    
    private LivePlayerData player;

    private void Start()
    {
        player = GetComponent<LivePlayerData>();
        DisplayPlayerData();
    }

    public void DisplayPlayerData()
    {
        if (lifePointText != null)
            lifePointText.text = player.CurrentLifePoints.ToString();
        if (portrait != null)
            portrait.sprite = player.Player.Portrait;
        if (currentManaText != null)
            currentManaText.text = player.CurrentMana.ToString();
        if (totalManaText != null)
            totalManaText.text = player.TotalMana.ToString();
    }
}

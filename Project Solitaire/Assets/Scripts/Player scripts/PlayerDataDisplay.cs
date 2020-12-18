using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text lifePointText = null;
    [SerializeField] private Image portrait = null;
    [SerializeField] private Image dominantManaImage = null;
    [SerializeField] private TMP_Text dominantManaText = null;
    

    [Header("Mana draw")]
    [SerializeField] private List<Image> manaImages = null;
    [SerializeField] private List<TMP_Text> manaTexts = null;


    private LivePlayerData player;

    private void Start()
    {
        player = GetComponent<LivePlayerData>();
        DisplayPlayerData();
        DisplayManaDraw();
    }

    public void DisplayPlayerData()
    {
        if (lifePointText != null)
            lifePointText.text = player.CurrentLifePoints.ToString();
        if (portrait != null)
            portrait.sprite = player.Player.Portrait;
        if (dominantManaImage != null)
            dominantManaImage.sprite = player.DominantMana.manaDepictionSprite;
        if (dominantManaText != null)
            dominantManaText.text = player.PlayerMana[player.DominantMana].ToString();
    }

    public void DisplayManaDraw()
    {
        if(manaImages.Count < player.PlayerMana.Count || manaTexts.Count < player.PlayerMana.Count) 
        { Debug.LogError("Mana: Insufficient images/text on Player Data Display"); return; }
        
        for(int i = 0; i < player.PlayerMana.Count; i++)
        {
            if (!manaImages[i].gameObject.activeSelf)
                manaImages[i].gameObject.SetActive(true);
            manaImages[i].sprite = player.PlayerMana.FirstValues[i].manaDepictionSprite;
            
            if (!manaTexts[i].gameObject.activeSelf)
                manaTexts[i].gameObject.SetActive(true);
            manaTexts[i].text = player.PlayerMana.SecondValues[i].ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class z_CardClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] LiveCardData data;
    private LivePlayerData player;

    private CardData card;
    private CardDataVariable liveCard;

    public UnityEvent OnClick;

    private void Awake()
    {
        player = FindObjectOfType<LivePlayerData>();
    }
    public void OnPointerClick(PointerEventData pData)
    {
        card = data.Card;
        BuyAndSell();
        GetIsPlayable();
        Invest();

        if (OnClick != null)
            OnClick.Invoke();
    }

    private void BuyAndSell()
    {
        if (card is CardData_Commander)
        {
            player.ModifyPlayerMana(data.currentContribution);
        }
        else if (card is CardData_CostBased)
        {
            ManaValueDictionary list = new ManaValueDictionary();

            foreach (ManaType type in data.currentCost.FirstValues)
            {
                list.Add(type, -data.currentCost[type]);
            }

            player.ModifyPlayerMana(list);
        }
    }

    private void GetIsPlayable()
    {
        data.GetIsCardPlayable();
        print("Playable = " + data.IsPlayable);
    }

    private void Invest()
    {
        liveCard.value = card;
    }
}

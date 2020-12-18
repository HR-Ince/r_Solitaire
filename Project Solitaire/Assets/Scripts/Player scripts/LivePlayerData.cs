using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivePlayerData : MonoBehaviour
{
    [SerializeField] private PlayerData player = null;
    public PlayerData Player { get { return player; } }
    [SerializeField] LiveManaValues playerMana = null;
    public ManaValueDictionary PlayerMana { get { return playerMana.list; } }

    [Min(0)] private int currentLifePoints;
    public int CurrentLifePoints { get { return currentLifePoints; } }
    public ManaType DominantMana { get; private set; }

    public UnityEvent OnValueChange;

    private void Awake()
    {
        currentLifePoints = player.LifePoints;

        DominantMana = PlayerMana.GetFirstMana();
    }

    private void SetDominantMana()
    {
        int i = 0;
        foreach(ManaType type in PlayerMana.FirstValues)
        {
            if (PlayerMana[type] > i)
            {
                DominantMana = type;
                i = PlayerMana[type];
            }
        }
    }

    public void ModifyPlayerLifePoints(int amount)
    {
        currentLifePoints += amount;
        if (OnValueChange != null)
            OnValueChange.Invoke();
    }

    public bool CardIsAffordable(ManaValueDictionary manaValues)
    {
        bool affordable = false;

        foreach(ManaType type in manaValues.FirstValues)
        {
            if (manaValues[type] >= PlayerMana[type])
                affordable = false;
            else
                affordable = true;
        }

        return affordable;
    }

    public void ModifyPlayerMana(ManaValueDictionary manaValues)
    {
        PlayerMana.Add(manaValues);
        SetDominantMana();
        if (OnValueChange != null)
            OnValueChange.Invoke();
    }
}

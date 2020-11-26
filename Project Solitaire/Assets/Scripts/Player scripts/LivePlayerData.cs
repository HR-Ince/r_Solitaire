using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivePlayerData : MonoBehaviour
{
    [SerializeField] private PlayerData player = null;
    [SerializeField] private List<ManaType> mana = new List<ManaType>();

    public List<ManaType> Mana { get { return mana; } }
    public PlayerData Player { get { return player; } }

    [Min(0)] private int currentLifePoints;
    public int CurrentLifePoints { get { return currentLifePoints; } }
    [Min(0)] private int currentMana;
    public int CurrentMana { get { return currentMana; } }
    [Min(0)] private int totalMana;
    public int TotalMana { get { return totalMana; } }

    public UnityEvent OnValueChange;

    private void Awake()
    {
        currentLifePoints = player.LifePoints;
    }

    public void ModifyPlayerLifePoints(int amount)
    {
        currentLifePoints += amount;
        if (OnValueChange != null)
            OnValueChange.Invoke();
    }

    public void ModifyPlayerMana(ManaType type, int amount)
    {
        foreach(ManaType manaType in Mana)
        {
            if(manaType == type)
            {
                manaType.amount += amount;
            }
        }
        if (OnValueChange != null)
            OnValueChange.Invoke();
    }
}

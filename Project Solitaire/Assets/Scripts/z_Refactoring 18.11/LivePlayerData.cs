using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePlayerData : MonoBehaviour
{
    [SerializeField] private PlayerData player;
    public PlayerData Player { get { return player; } }

    [Min(0)] private int currentLifePoints;
    public int CurrentLifePoints { get { return currentLifePoints; } }
    [Min(0)] private int currentMana;
    public int CurrentMana { get { return currentMana; } }
    [Min(0)] private int totalMana;
    public int TotalMana { get { return totalMana; } }

    private void Awake()
    {
        currentLifePoints = player.LifePoints;
    }

    public void ModifyPlayerLifePoints(int amount)
    {
        currentLifePoints += amount;
    }

    public void ModifyPlayerCurrentMana(int amount)
    {
        currentMana += amount;
    }

    public void ModifyPlayerTotalMana(int amount)
    {
        totalMana += amount;
    }
}

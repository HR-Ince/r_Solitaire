using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player/Hand")]
public class PlayerHand : ScriptableObject
{
    public List<LiveCardData> playerHand = new List<LiveCardData>();

    private void OnEnable()
    { playerHand.Clear(); }

    public void AddCardToHand(LiveCardData card)
    { playerHand.Add(card); }
}

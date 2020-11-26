using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hand", menuName = "Set/Hand")]
public class PlayerHand : ScriptableObject
{
    public List<GameObject> list = new List<GameObject>();

    private void OnEnable()
    { list.Clear(); }

    public void AddCardToHand(GameObject card)
    { list.Add(card); }
}

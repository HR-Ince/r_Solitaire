using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private Sprite portrait = null;
    [SerializeField] private int lifePoints = 20;

    public Sprite Portrait { get { return portrait; } }
    public int LifePoints { get { return lifePoints; } set { lifePoints = value; } }
}

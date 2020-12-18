using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mana Type", menuName = "Variable/Mana Type")]
public class ManaType : ScriptableObject
{
    [SerializeField] private LiveManaValues manaList = null;

    public Sprite manaDepictionSprite = null;
    
    private void OnEnable()
    {
        if(manaList != null && !manaList.list.Contains(this))
            manaList.list.Add(this);
    }
}

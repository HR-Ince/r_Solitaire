using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mana Data List", menuName = "Variable/Mana Data List")]
public class LiveManaValues : ScriptableObject
{    
    public ManaValueDictionary list = new ManaValueDictionary();
}

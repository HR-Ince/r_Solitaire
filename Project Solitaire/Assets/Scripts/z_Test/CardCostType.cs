using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardCostType : ScriptableObject
{
    public abstract bool GetIsPlayable();
}

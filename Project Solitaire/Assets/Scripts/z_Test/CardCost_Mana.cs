using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCost_Mana : CardCostType
{
    public ManaValueDictionary values;

    public override bool GetIsPlayable()
    {
        return true;
    }
}

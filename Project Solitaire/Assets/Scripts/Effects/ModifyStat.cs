using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModifyStatEffect", menuName = "Effects/Effect: Modify Stat")]
public class ModifyStat : UnitEffect
{
    private enum StatType
    {
        Attack,
        Defence,
        Cost,
        Rank
    }

    [SerializeField] private int statModifier = 0;
    [SerializeField] private StatType statToModify = StatType.Attack;

    public override void ActivateEffect()
    {
        if(target == null) { Debug.LogError("Effect has no target"); return; }
        if (statToModify == StatType.Attack)
            target.ModifyAtk(statModifier);
        else if (statToModify == StatType.Defence)
            target.ModifyDef(statModifier);
        else if (statToModify == StatType.Cost)
            Debug.Log("Modifying cost by" + statModifier.ToString());
        else if (statToModify == StatType.Rank)
            Debug.Log("Modifying Rank by" + statModifier.ToString());
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Displayable
{
    public enum EffectActivationType
    {
        Null,
        OnAttackingDirectly,
        OnAttackingUnit,
        OnDefence,
        OnActivation,
        OnDeployment
    }

    public string unitName = null;
    public Material counterMaterial = null;
    public EffectActivationType effectActivationCondition;
    public bool effectDoesTarget = false;
    public string effectText;
    public int atk = 0;
}

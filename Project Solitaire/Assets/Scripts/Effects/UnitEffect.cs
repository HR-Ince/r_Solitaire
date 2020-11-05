using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect : ScriptableObject
{
    [HideInInspector]
    public UnitManifestation target = null;

    public virtual void ActivateEffect()
    {

    }
}

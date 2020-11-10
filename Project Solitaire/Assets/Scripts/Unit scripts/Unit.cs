using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private Material _counterMaterial = null;
    [SerializeField] private EffectActivationType _effectActivationCondition;
    [SerializeField] private bool _effectDoesTarget = false;
    [SerializeField] private UnitEffect _effect = null;
    [SerializeField] private string _effectText;
    [SerializeField] private int _atk = 0;
    [SerializeField] private int _health = 0;

    public Material CounterMaterial { get { return _counterMaterial; } private set { _counterMaterial = value; } }
    public EffectActivationType EffectActivationCondition { get { return _effectActivationCondition; } private set { _effectActivationCondition = value; } }
    public bool EffectDoesTarget { get { return _effectDoesTarget; } private set { _effectDoesTarget = value; } }
    public UnitEffect Effect { get { return _effect; } private set { _effect = value; } }
    public string effectText { get { return _effectText; } private set { _effectText = value; } }
    public int Atk { get { return _atk; } private set { _atk = value; } }
    public int Health { get { return _health; } private set { _health = value; } }
}

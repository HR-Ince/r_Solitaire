using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SO_Unit : ScriptableObject
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

    [SerializeField] private string _unitName = null;
    public string UnitName { get { return _unitName; } private set { _unitName = value; } }


    [SerializeField] private Sprite _cardImage = null;
    public Sprite CardImage { get { return _cardImage; } private set { _cardImage = value; } }
    
    [SerializeField] private Material _counterMaterial = null;
    public Material CounterMaterial { get { return _counterMaterial; } private set { _counterMaterial = value; } }


    [SerializeField] private EffectActivationType _effectActivationCondition;
    public EffectActivationType EffectActivationCondition { get { return _effectActivationCondition; } private set { _effectActivationCondition = value; } }

    [SerializeField] private bool _effectDoesTarget = false;
    public bool EffectDoesTarget { get { return _effectDoesTarget; } private set { _effectDoesTarget = value; } }

    [SerializeField] private UnitEffect _effect = null;
    public UnitEffect Effect { get { return _effect; } private set { _effect = value; } }

    [SerializeField] private string _effectText;
    public string effectText { get { return _effectText; } private set { _effectText = value; } }

    [SerializeField] private int _atk = 0;
    public int Atk { get { return _atk; } private set { _atk = value; } }
    
    [SerializeField] private int _def = 0;
    public int Def { get { return _def; } private set { _def = value; } }
}

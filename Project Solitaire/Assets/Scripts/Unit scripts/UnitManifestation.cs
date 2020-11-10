using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitManifestation : MonoBehaviour
{
    public int CurrentAtk { get; protected set; }
    public int CurrentDef { get; protected set; }
    public Unit Unit { get; private set; }

    [SerializeField] protected LayerMask boardMask;
    [SerializeField] protected LayerMask counterMask;

    protected bool isCard;
    protected GameController game;
    protected PlayerController player;


    public void CreateFromUnit(Unit unit)
    {
        this.Unit = unit;
        SetupVariables();
    }

    public virtual void SetupVariables()
    {
        Debug.LogError("Unit manifestation SetupVariables() accessed");
    }

    public bool HasEffectOfType(Unit.EffectActivationType type)
    {
        return Unit.EffectActivationCondition == type;
    }

    protected void OnMouseDown()
    {
        if (HasEffectOfType(Unit.EffectActivationType.OnActivation))
        {
            player.Display.DisplayEffectActivationButtonFor(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitManifestation : MonoBehaviour
{
    public int CurrentAtk { get; protected set; }
    public int CurrentDef { get; protected set; }
    public SO_Unit Unit { get; private set; }

    [SerializeField] protected LayerMask boardMask;
    [SerializeField] protected LayerMask counterMask;

    protected bool isCard;
    protected GameController game;
    protected PlayerController player;
    protected UnitDisplay display;


    public void CreateFromUnit(SO_Unit unit)
    {
        this.Unit = unit;
        SetupVariables();
        SetupDisplay();
    }

    private void SetupDisplay()
    {
        display = GetComponent<UnitDisplay>();
        display.isCard = isCard;
        display.Setup(Unit);
    }

    public virtual void SetupVariables()
    {
        Debug.LogError("Unit manifestation SetupVariables() accessed");
    }

    public bool HasEffectOfType(SO_Unit.EffectActivationType type)
    {
        return Unit.EffectActivationCondition == type;
    }

    protected void OnMouseDown()
    {
        if (!player.IsMyTurn) { return; }
        display.DisplayDetail();
        if (HasEffectOfType(SO_Unit.EffectActivationType.OnActivation))
        {
            player.Display.DisplayEffectActivationButtonFor(this);
        }
    }
    public void ModifyAtk(int amount)
    {
        CurrentAtk += amount;
        if (CurrentAtk < 0) CurrentAtk = 0;
        display.UpdateAtkText(CurrentAtk);
    }

    public void ModifyDef(int amount)
    {
        CurrentDef += amount;
        if (CurrentDef < 0) CurrentDef = 0;
        display.UpdateDefText(CurrentDef);
    }

}

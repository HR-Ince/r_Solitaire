using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDisplayFromUnit : MonoBehaviour
{
    [SerializeField] UnitHolder unitHolder = null;

    [SerializeField] Display display = null;
    [SerializeField] DynamicUIElements dynamics = null;

    public void Start()
    {
        if (display == null)
        { Debug.LogError("No display script on " + name); return; }
        if (dynamics == null)
            Debug.LogError("Dynamic UI missing from " + name);

        Unit unit = unitHolder.GetUnit();

        display.DisplayStaticElements(unit);
        dynamics.display = display;

        dynamics.baseAtk = unit.Atk;
        dynamics.baseHealth = unit.Health;

        if (unit is BasicUnit basic)
            dynamics.baseCost = basic.Cost;

        dynamics.SetStatsToBase();
    }
}

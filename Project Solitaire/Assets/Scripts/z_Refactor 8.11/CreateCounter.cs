using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCounter : MonoBehaviour
{
    [SerializeField] GameObject counterBase;

    public void CreateCounterFromUnit(Unit unit)
    {
        var counter = Instantiate(counterBase);
        if(!counter.TryGetComponent<UnitHolder>(out UnitHolder holder)) { Debug.LogError("Counter missing Unit Holder"); return; }
        else
        {
            holder.SetUnit(unit);
        }
    }
}

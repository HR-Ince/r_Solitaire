using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableUnit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Serializable]
    public class OnMouseDown : UnityEvent<Unit> { }
    [Serializable]
    public class OnMouseUp : UnityEvent<Unit> { }

    public OnMouseDown WhenPressed;
    public OnMouseUp WhenReleased;

    private Unit unit;

    private void Start()
    {
        if(!TryGetComponent(out UnitHolder unitHolder)) { Debug.LogError("Clickable Unit missing Unit Holder"); return; }
        else
        {
            unit = unitHolder.GetUnit();
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (WhenPressed != null)
            WhenPressed.Invoke(unit);
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (WhenReleased != null)
            WhenReleased.Invoke(unit);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MoveWithDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 dragOffset;

    [Serializable]
    public class OnRelease : UnityEvent<Unit> { }

    public OnRelease WhenReleasing;

    public void OnBeginDrag(PointerEventData data)
    {
        GetDragOffset();
    }

    private void GetDragOffset()
    {
        dragOffset = transform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData data)
    {
        DragObj();
    }

    private void DragObj()
    {
        transform.position = Input.mousePosition + dragOffset;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if(WhenReleasing != null)
        {
            if(TryGetComponent<UnitHolder>(out UnitHolder unitHolder))
            {
                Unit unit = unitHolder.GetUnit();
                WhenReleasing.Invoke(unit);
            }
            Destroy(this.gameObject);
        }
    }

}

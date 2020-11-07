using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card2D : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 dragOffset;
    private SO_Unit unit;

    private ObjectHandler objectHandler;

    private void Start()
    {
        FindObjectOfType<ObjectHandler>();
    }

    public void OnPointerDown(PointerEventData data)
    {

    }

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
        DragCard();
    }

    private void DragCard()
    {
        transform.position = Input.mousePosition + dragOffset;
    }

    public void OnEndDrag(PointerEventData data)
    {
        objectHandler.CreateCounter(unit);
    }

}

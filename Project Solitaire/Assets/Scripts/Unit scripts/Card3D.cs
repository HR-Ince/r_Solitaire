using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card3D : UnitManifestation
{
    [Header("Mechanical Setup")]
    [SerializeField] LayerMask backBoardMask = 0;
    [SerializeField] float cardFloatHeight = 1f;
    [SerializeField] float distanceUntilParallelToBoard = 2f;

    private bool isBeingDragged = false;
    private float startAngleX = 0f;

    private ObjectHandler objHandler;

    public override void SetupVariables()
    {
        game = FindObjectOfType<GameController>();
        player = GetComponentInParent<PlayerController>();
        objHandler = FindObjectOfType<ObjectHandler>();

        isCard = true;

        CurrentAtk = Unit.Atk;
        CurrentDef = Unit.Def;

        startAngleX = transform.rotation.eulerAngles.x;
    }

    public void OnMouseDrag()
    {
        player.Display.HideEffectActivationButton();
        if (!player.IsMyTurn) { return; }
        if (Unit is BasicUnit)
        {
            BasicUnit basicUnit = (BasicUnit)Unit;
            if (player.ManaCostIsAffordable(basicUnit.cost))
            {
                DragCard();
            }
        }
        else if(Unit is CommanderUnit)
        {
            DragCard();
        }
        
    }

    private void DragCard()
    {
        RaycastHit hit;
        if (!Physics.Raycast(player.Cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, backBoardMask))
        {
            Debug.LogError("Ray missing mask");
            return;
        }
        else
        {
            player.Hand.RemoveCardFromHand(this);
            transform.position = new Vector3(hit.point.x, cardFloatHeight, hit.point.z);
            isBeingDragged = true;
            RotateCardParallelToBoard();
        }
    }

    private void RotateCardParallelToBoard()
    {
        float distanceFromHand = Mathf.Abs(transform.position.z - transform.parent.position.z);
        float f = distanceFromHand / distanceUntilParallelToBoard;
        float angleDiff = 90f - startAngleX;
        float xAngle = Mathf.Clamp(f * angleDiff, startAngleX, 90f);
        transform.rotation = Quaternion.Euler(xAngle, transform.rotation.eulerAngles.y, 0);
    }

    private void OnMouseUp()
    {
        if (!player.IsMyTurn) { return; }
        if (isBeingDragged)
        {
            if(!Physics.Raycast(player.Cam.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, boardMask))
            {
                player.Hand.AddCardToHand(this);
            }
            else
            {
                objHandler.CreateCounter(player, Unit);
                if(Unit is BasicUnit basicUnit) { player.SpendMana(basicUnit.cost); }
                Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCounter : UnitManifestation
{
    private bool isTargeting;
    private bool hasMoved = false;

    private BattleManager battleManager;

    public override void SetupVariables()
    {
        battleManager = FindObjectOfType<BattleManager>();
        game = FindObjectOfType<GameController>();
        player = GetComponentInParent<PlayerController>();

        isCard = false;
        
        CurrentAtk = Unit.Atk;
        CurrentDef = Unit.Def;
    }

    public void ActivateEffect()
    {
        StartCoroutine(EffectTargeting());
        Unit.Effect.ActivateEffect();
        if (HasEffectOfType(SO_Unit.EffectActivationType.OnActivation))
        {
            player.Display.HideEffectActivationButton();
        }
    }

    public void ResetForTurn()
    {
        hasMoved = false;
        if (player.Board.CounterIsAdvanced(this))
        {
            player.Board.AddCounterToMain(this);
        }
    }

    private IEnumerator EffectTargeting()
    {
        if (Unit.EffectDoesTarget)
        {
            Debug.Log("Choose your target.");
            game.effectIsTargeting = true;
            yield return new WaitWhile(() => game.effectIsTargeting);

            Unit.Effect.target = game.Target;
        }
        else
        {
            Unit.Effect.target = this;
        }
    }

    public void TakeDamage(int damage)
    {
        ModifyDef(-damage);
    }

    public void DeclareDead()
    {
        print(Unit.name + " has died.");
        player.Graveyard.AddToGraveyard(Unit);
        Destroy(this.gameObject);
    }

    private void OnMouseDrag()
    {
        if (!player.Board.CounterIsWithdrawn(this))
        {
            isTargeting = true;
        }
    }

    private void OnMouseUp()
    {
        player.Display.HideEffectActivationButton();
        if (isTargeting)
            MoveCounter();
    }

    private void MoveCounter()
    {
        if (hasMoved) { return; }

        Physics.Raycast(player.Cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity);
        PlayerController objectHitOwner = hit.transform.GetComponentInParent<PlayerController>();

        Vector3 toHit = hit.point - transform.position;
        float angleToHit = Vector3.SignedAngle(Vector3.forward, toHit, Vector3.up);

        if (player.TurnPhase == TurnManager.TurnPhase.Main1
            || player.TurnPhase == TurnManager.TurnPhase.Main2)
        {
            if (angleToHit < -90 || angleToHit > 90)
            {
                if (player.Board.CounterIsInMain(this))
                {
                    player.Board.AddCounterToWithdrawn(this);
                    hasMoved = true;
                }
            }
        }
        else if(player.TurnPhase == TurnManager.TurnPhase.Battle)
        {
            if (objectHitOwner == player.Opponent)
            {
                if (hit.transform.TryGetComponent<UnitCounter>(out UnitCounter enemyCounter))
                {
                    if (player.Opponent.Board.CounterIsAdvanced(enemyCounter))
                    {
                        battleManager.Battle(this, enemyCounter);
                        player.Board.AddCounterToAdvanced(this);
                    }
                }
                else if(!player.Opponent.Board.HasCountersAdvanced())
                {
                    battleManager.AddToDirectAttackers(this);
                    player.Board.AddCounterToAdvanced(this);
                }
                else
                {
                    return;
                }
            }
        
        }
        isTargeting = false;
    }
}

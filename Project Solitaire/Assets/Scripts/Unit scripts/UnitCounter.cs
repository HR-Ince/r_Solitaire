using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCounter : UnitManifestation
{
    private bool isTargeting;
    private bool hasEffect = false;

    private BattleManager battleManager;

    public override void SetupVariables()
    {
        battleManager = FindObjectOfType<BattleManager>();
        game = FindObjectOfType<GameController>();
        player = GetComponentInParent<PlayerController>();

        isCard = false;

        if(Unit.Effect != null)
        {
            hasEffect = true;
        }
        
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
        if (!player.IsMyTurn) { return; }
        if (!player.Board.IsWithdrawn(this))
        {
            isTargeting = true;
        }
    }

    private void OnMouseUp()
    {
        player.Display.HideEffectActivationButton();
        if (!player.IsMyTurn) { return; }
        if (isTargeting)
        {
            Physics.Raycast(player.Cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity);
            PlayerController objectHitOwner = hit.transform.GetComponentInParent<PlayerController>();

            if(Mathf.Abs(hit.point.z) > Mathf.Abs(transform.position.z))
            {
                if (battleManager.DoesAttackersContain(this)) { battleManager.RemoveFromAttackers(this); }
                player.Board.AddCounterToMain(this);
            }
            else if (objectHitOwner == player.Opponent)
            {
                if (player.Board.IsAdvanced(this)) { return; }
                player.Board.AddCounterToAdvanced(this);

                if (hit.transform.TryGetComponent<UnitCounter>(out UnitCounter enemyCounter))
                {
                    if (player.Opponent.Board.IsAdvanced(enemyCounter))
                    {
                        battleManager.Battle(this, enemyCounter);
                    }
                }
                else
                {
                    battleManager.AddToDirectAttackers(this);
                }
            }
            isTargeting = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    [Header("Base Objects")]
    [SerializeField] Card3D cardBase = null;
    [SerializeField] UnitCounter counterBase = null;

    public void CreateCard(PlayerController player, SO_Unit unit)
    {
        Card3D card = Instantiate(cardBase, player.Hand.transform);
        card.CreateFromUnit(unit);
        player.Hand.AddCardToHand(card);
    }
    public void CreateCounter(PlayerController player, SO_Unit unit)
    {
        UnitCounter counter = Instantiate(counterBase, player.Board.transform);
        counter.CreateFromUnit(unit);

        if (unit is CommanderUnit commander)
        {
            player.Board.AddCounterToWithdrawn(counter);
            player.IncreaseManaBy(commander.manaContribution);
        }
        else
        {
            player.Board.AddCounterToMain(counter);
        }
    }
}

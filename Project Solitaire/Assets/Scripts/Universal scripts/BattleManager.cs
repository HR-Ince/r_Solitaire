using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public struct BattleInstance
    {
        public List<UnitCounter> defendingCounters;
        public List<UnitCounter> attackingCounters;
    }

    List<UnitCounter> directAttackers = new List<UnitCounter>();
    List<BattleInstance> battles = new List<BattleInstance>();

    private void Start()
    {
        BattleManager[] battleManagers = FindObjectsOfType<BattleManager>();
        if(battleManagers.Length > 1)
        {
            Destroy(this);
        }
    }

    //PLACEHOLDER
    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            CommenceBattles();
        }
    }

    public void Battle(UnitCounter attacker, UnitCounter defender)
    {
        if (directAttackers.Contains(defender))
        {
            directAttackers.Remove(defender);
        }
        foreach(BattleInstance battle in battles)
        {
            if(battle.defendingCounters.Contains(defender))
            {
                battle.attackingCounters.Add(attacker);
                return;
            }
        }
        BattleInstance newBattle = new BattleInstance();
        newBattle.defendingCounters = new List<UnitCounter>();
        newBattle.defendingCounters.Add(defender);
        newBattle.attackingCounters = new List<UnitCounter>();
        newBattle.attackingCounters.Add(attacker);
        battles.Add(newBattle);
    }

    public void AddToDirectAttackers(UnitCounter counter)
    {
        directAttackers.Add(counter);
    }

    public bool DoesAttackersContain(UnitCounter counter)
    {
        foreach(BattleInstance battle in battles)
        {
            if (battle.attackingCounters.Contains(counter))
            {
                return true;
            }
        }
        foreach(UnitCounter directAttacker in directAttackers)
        {
            if(directAttacker == counter)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveFromAttackers(UnitCounter counter)
    {
        foreach (BattleInstance battle in battles)
        {
            if (battle.attackingCounters.Contains(counter))
            {
                battle.attackingCounters.Remove(counter);
                if (battle.attackingCounters.Count <= 0)
                {
                    battles.Remove(battle);
                }
            }
        }

        if (directAttackers.Contains(counter))
        {
            directAttackers.Remove(counter);
        }
    }

    public void CommenceBattles()
    {
        print("Battle commenced! There are " + battles.Count.ToString() + " battles, and " + directAttackers.Count.ToString() + " direct attackers.");
        foreach (BattleInstance battle in battles)
        {
            foreach(UnitCounter attacker in battle.attackingCounters)
            {
                if (attacker.HasEffectOfType(SO_Unit.EffectActivationType.OnAttackingUnit))
                {
                    attacker.ActivateEffect();
                }
                battle.defendingCounters[0].TakeDamage(attacker.CurrentAtk);
                if(battle.attackingCounters.Count > 1)
                {
                    print("Choose your victim.");
                }
                else
                {
                    foreach(UnitCounter defender in battle.defendingCounters)
                    {
                        attacker.TakeDamage(defender.CurrentAtk);
                        StartCoroutine(CheckForSignsOfLife(defender));
                        StartCoroutine(CheckForSignsOfLife(attacker));
                    }
                }
            }
        }
        
        foreach(UnitCounter attacker in directAttackers)
        {
            if (attacker.HasEffectOfType(SO_Unit.EffectActivationType.OnAttackingDirectly))
            {
                attacker.ActivateEffect();
            }
            PlayerController opponent = attacker.GetComponentInParent<PlayerController>().Opponent;
            opponent.TakeLifepointDamage(attacker.CurrentAtk);
        }

        battles.Clear();
        directAttackers.Clear();
    }

    IEnumerator CheckForSignsOfLife(UnitCounter counter)
    {
        if(counter.CurrentDef <= 0)
        {
            yield return new WaitForSeconds(3f);
            counter.DeclareDead();
        }
    }
}

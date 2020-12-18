using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardConstructor : MonoBehaviour
{
    [SerializeField] LiveManaValues totalMana = null;
    [SerializeField] CommandersOnField commanders = null;

    public void AssignCard(CardData data)
    {
        if (data is CardData_Commander commanderData)
        {
            CardData_Commander commander = ScriptableObject.CreateInstance<CardData_Commander>();
            commander.Construct(commanderData);

            var liveData = gameObject.AddComponent<LiveData_Commander>();
            liveData.card = commander;

        }
        else if(data is CardData_CostBased costlyData)
        {
            CardData_CostBased costly = ScriptableObject.CreateInstance<CardData_CostBased>();
            costly.Construct(costlyData);
        }

        if(data is CardData_Unit unitData)
        {
            CardData_Unit unit = ScriptableObject.CreateInstance<CardData_Unit>();
            unit.Construct(unitData);
        }
    }
}

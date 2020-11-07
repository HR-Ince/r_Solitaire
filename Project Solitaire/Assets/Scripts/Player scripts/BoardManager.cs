using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] float distanceBtwnCounters = 1f, counterHalfHeight = 0.1f;
    [SerializeField] Vector3 mainBasePos = new Vector3(0f, 0f, 0f);
    [SerializeField] Vector3 advanceBasePos = new Vector3(0f, 0f, 3f);
    [SerializeField] Vector3 withdrawnBasePos = new Vector3(0f, 0f, -3f);

    List<UnitCounter> countersInMain = new List<UnitCounter>();
    List<UnitCounter> countersAdvanced = new List<UnitCounter>();
    List<UnitCounter> countersWithdrawn = new List<UnitCounter>();

    List<UnitCounter> countersOnBoard = new List<UnitCounter>();

    public List<UnitCounter> GetCountersOnBoard()
    {
        countersOnBoard.Clear();

        foreach(UnitCounter counter in countersInMain)
        {
            countersOnBoard.Add(counter);
        }

        foreach(UnitCounter counterA in countersAdvanced)
        {
            countersOnBoard.Add(counterA);
        }

        foreach(UnitCounter counterW in countersWithdrawn)
        {
            countersOnBoard.Add(counterW);
        }

        return countersOnBoard;
    }

    public void AddCounterToMain(UnitCounter counter)
    {
        CleanCounter(counter);
        countersInMain.Add(counter);
        counter.transform.localPosition = mainBasePos;
        ArrangeAllCounters();
    }

    public void AddCounterToAdvanced(UnitCounter counter)
    {
        CleanCounter(counter);
        countersAdvanced.Add(counter);
        counter.transform.localPosition = advanceBasePos;
        ArrangeAllCounters();
    }

    public bool HasCountersAdvanced()
    {
        return countersAdvanced.Count > 0;
    }

    public void AddCounterToWithdrawn(UnitCounter counter)
    {
        CleanCounter(counter);
        countersWithdrawn.Add(counter);
        counter.transform.localPosition = withdrawnBasePos;
        ArrangeAllCounters();
    }

    public void CleanCounter(UnitCounter counter)
    {
        if (countersInMain.Contains(counter))
        {
            countersInMain.Remove(counter);
            return;
        }
        else if (countersWithdrawn.Contains(counter))
        {
            countersWithdrawn.Remove(counter);
            return;
        }
        else if(countersAdvanced.Contains(counter))
        {
            countersAdvanced.Remove(counter);
            return;
        }
    }
    public bool CounterIsInMain(UnitCounter counter)
    {
        return countersInMain.Contains(counter);
    }

    public bool CounterIsAdvanced(UnitCounter counter)
    {
        return countersAdvanced.Contains(counter);
    }

    public bool CounterIsWithdrawn(UnitCounter counter)
    {
        return countersWithdrawn.Contains(counter);
    }

    public void ArrangeAllCounters()
    {
        ArrangeCountersIn(countersInMain);
        ArrangeCountersIn(countersAdvanced);
        ArrangeCountersIn(countersWithdrawn);
    }

    private void ArrangeCountersIn(List<UnitCounter> countersToSort)
    {
        float rangeMid = (countersToSort.Count / 2f) - 0.5f;
        for (int i = 0; i < countersToSort.Count; i++)
        {
            float newX = (i - rangeMid) * distanceBtwnCounters;

            countersToSort[i].transform.position = new Vector3(newX, transform.position.y + counterHalfHeight, countersToSort[i].transform.position.z);
        }
    }
}

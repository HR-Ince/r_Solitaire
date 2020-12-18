using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickToAwake : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject sleepingThing = null;

    public UnityEvent beforeAwake;

    public void OnPointerClick(PointerEventData data)
    {
        if (beforeAwake != null)
            beforeAwake.Invoke();

        if (sleepingThing != null && !sleepingThing.activeSelf)
            sleepingThing.SetActive(true);
    }

}

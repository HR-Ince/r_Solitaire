using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.RemoveListener(this); }

    public void OnEventRaised()
    { response.Invoke(); }
}

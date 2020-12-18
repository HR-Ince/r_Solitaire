using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Android;

public class InputHandler : MonoBehaviour
{
    public UnityEvent OnPressed;

    private void OnMouseDown()
    {
        if (OnPressed != null)
            OnPressed.Invoke();
    }
}

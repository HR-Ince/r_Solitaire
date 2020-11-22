using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceholderInputs : MonoBehaviour
{
    public UnityEvent dPressed;
    public UnityEvent zPressed;

    private void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            if(dPressed != null)
                dPressed.Invoke();
        }
        if (Input.GetKeyDown("z"))
        {
            if (zPressed != null)
                zPressed.Invoke();
        }
    }
}

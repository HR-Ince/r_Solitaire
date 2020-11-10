using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDisplayFromPlayer : MonoBehaviour
{
    
    [SerializeField] Display display = null;
    [SerializeField] DynamicUIElements dynamics = null;
    [SerializeField] DisplayablePlayer player = null;

    public void Start()
    {
        if (display == null)
        { Debug.LogError("No display script on " + name); return; }
        if (dynamics == null)
            Debug.LogError("Dynamic UI missing from " + name);

        display.DisplayStaticElements(player);

        dynamics.baseHealth = player.health;
        dynamics.baseMana = player.baseMana;
    }
}

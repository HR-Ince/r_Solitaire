using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool effectIsTargeting = false;
    public PlayerController activePlayer { get; private set; }
    [SerializeField] LayerMask counterMask = 0;

    public UnitManifestation Target { get; private set; }

    private Camera cam = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (effectIsTargeting)
            {
                GetTargetCounter();
            }
        }

        if (Input.GetKeyDown("e"))
        {
            EmptyHand();
        }
    }

    private void GetTargetCounter()
    {
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, counterMask)) { return; }
        else
        {
            Target = hit.transform.GetComponent<UnitCounter>();
            effectIsTargeting = false;
        }

    }

    private void EmptyHand()
    {
        Card3D[] cardsinHand = activePlayer.Hand.GetComponentsInChildren<Card3D>();
        foreach(Card3D card in cardsinHand)
        {
            activePlayer.Hand.RemoveCardFromHand(card);
            Destroy(card.gameObject);
        }
    }
}

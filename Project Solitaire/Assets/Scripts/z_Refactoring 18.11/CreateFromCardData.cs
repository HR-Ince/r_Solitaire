using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFromCardData : MonoBehaviour
{
    [SerializeField] private GameObject objToCreate;
    [SerializeField] private bool is2D;

    public void Create()
    {
        var obj = Instantiate(objToCreate);
        if (is2D)
            obj.transform.SetParent(FindObjectOfType<Canvas>().transform);
    }
}

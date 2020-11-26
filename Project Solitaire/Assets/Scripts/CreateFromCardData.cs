using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFromCardData : MonoBehaviour
{
    [SerializeField] private CardDataVariable cardData = null;
    [SerializeField] private GameObject objToCreate = null;
    [SerializeField] private bool is2D = true;

    public void Create()
    {
        var obj = Instantiate(objToCreate);
        if (is2D)
            obj.transform.SetParent(FindObjectOfType<Canvas>().transform);

        var dataManager = obj.GetComponent<LiveCardData>();
        dataManager.SetCardData(cardData.value);

    }
}

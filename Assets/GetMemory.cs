using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMemory : MonoBehaviour
{

    [SerializeField] private GameObject memoryObject;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<Memory>())
        {
            memoryObject = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == memoryObject && memoryObject != null)
        {
            memoryObject = null;
        }
    }
}

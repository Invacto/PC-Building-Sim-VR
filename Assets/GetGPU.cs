using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGPU : MonoBehaviour
{
    [SerializeField] private GameObject gpuObject;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<GPU>())
        {
            gpuObject = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == gpuObject && gpuObject != null)
        {
            gpuObject = null;
        }
    }
}

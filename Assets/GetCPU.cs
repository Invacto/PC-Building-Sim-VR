using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCPU : MonoBehaviour
{
    [SerializeField] private GameObject cpuObject;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<CPU>())
        {
            cpuObject = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == cpuObject && cpuObject != null)
        {
            cpuObject = null;
        }
    }
}

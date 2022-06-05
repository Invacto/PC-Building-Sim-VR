using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCPUCooler : MonoBehaviour
{
    [SerializeField] private GameObject cpuCoolerObject;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<CPUFan>())
        {
            cpuCoolerObject = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == cpuCoolerObject && cpuCoolerObject != null)
        {
            cpuCoolerObject = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GetCPU : MonoBehaviour
{

    [SerializeField] private GameObject _cpuObject;

    public GameObject CPU { get { return _cpuObject; } }

    private bool rightGripValue;
    private bool leftGripValue;
    private bool handInTrigger;

    private void Update()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        rightHand.TryGetFeatureValue(CommonUsages.gripButton, out rightGripValue);
        leftHand.TryGetFeatureValue(CommonUsages.gripButton, out leftGripValue);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.GetComponent<XRDirectInteractor>())
        {
            handInTrigger = true;
        }
        else
        {
            handInTrigger = false;
        }

        if (collider.gameObject.GetComponent<CPU>())
        {
            _cpuObject = collider.gameObject;

            if (!rightGripValue && handInTrigger)
            {
                BoxCollider[] colliders = _cpuObject.GetComponents<BoxCollider>();

                foreach (BoxCollider boxCollider in colliders)
                {
                    boxCollider.enabled = false;
                }
            }
        }


        if (_cpuObject != null && _cpuObject.GetComponent<CPU>() && collider.gameObject.GetComponent<XRDirectInteractor>())
        {
            BoxCollider[] colliders = _cpuObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == _cpuObject && _cpuObject != null)
        {
            BoxCollider[] colliders = _cpuObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }

            _cpuObject = null;
        }
    }
}

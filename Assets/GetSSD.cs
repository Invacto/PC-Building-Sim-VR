using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GetSSD : MonoBehaviour
{
    [SerializeField] private GameObject _ssdObject;

    public GameObject SSD { get { return _ssdObject; } }

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


        if (collider.gameObject.GetComponent<SSD>())
        {
            _ssdObject = collider.gameObject;

            if (!rightGripValue && handInTrigger)
            {
                BoxCollider[] colliders = _ssdObject.GetComponents<BoxCollider>();

                foreach (BoxCollider boxCollider in colliders)
                {
                    boxCollider.enabled = false;
                }
            }
        }


        if (_ssdObject != null && _ssdObject.GetComponent<SSD>() && collider.gameObject.GetComponent<XRDirectInteractor>())
        {
            BoxCollider[] colliders = _ssdObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == _ssdObject && _ssdObject != null)
        {
            BoxCollider[] colliders = _ssdObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }

            _ssdObject = null;

        }
    }
}

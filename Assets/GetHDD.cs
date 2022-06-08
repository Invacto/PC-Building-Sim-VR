using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GetHDD : MonoBehaviour
{
    [SerializeField] private GameObject _hddObject;

    public GameObject HDD { get { return _hddObject; } }

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


        if (collider.gameObject.GetComponent<HDD>())
        {
            _hddObject = collider.gameObject;

            if (!rightGripValue && handInTrigger)
            {
                BoxCollider[] colliders = _hddObject.GetComponents<BoxCollider>();

                foreach (BoxCollider boxCollider in colliders)
                {
                    boxCollider.enabled = false;
                }
            }
        }


        if (_hddObject != null && _hddObject.GetComponent<HDD>() && collider.gameObject.GetComponent<XRDirectInteractor>())
        {
            BoxCollider[] colliders = _hddObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == _hddObject && _hddObject != null)
        {
            BoxCollider[] colliders = _hddObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }

            _hddObject = null;

        }
    }
}

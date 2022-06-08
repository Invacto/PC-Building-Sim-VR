using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GetGPU : MonoBehaviour
{
    [SerializeField] private GameObject _gpuObject;

    public GameObject GPU { get { return _gpuObject; } }

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

        if (collider.gameObject.GetComponent<GPU>())
        {
            _gpuObject = collider.gameObject;

            if (!rightGripValue && handInTrigger)
            {
                BoxCollider[] colliders = _gpuObject.GetComponents<BoxCollider>();

                foreach (BoxCollider boxCollider in colliders)
                {
                    boxCollider.enabled = false;
                }
            }
        }


        if (_gpuObject != null && _gpuObject.GetComponent<GPU>() && collider.gameObject.GetComponent<XRDirectInteractor>())
        {
            BoxCollider[] colliders = _gpuObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == _gpuObject && _gpuObject != null)
        {
            BoxCollider[] colliders = _gpuObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }

            _gpuObject = null;
        }
    }
}

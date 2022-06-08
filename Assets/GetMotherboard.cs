using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GetMotherboard : MonoBehaviour
{
    [SerializeField] private GameObject motherboardObject;

    public GameObject Motherboard { get { return motherboardObject;  } }

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


        if (collider.gameObject.GetComponent<MotherBoard>())
        {
            motherboardObject = collider.gameObject;

            if (!rightGripValue && handInTrigger)
            {
                BoxCollider[] colliders = motherboardObject.GetComponents<BoxCollider>();

                foreach (BoxCollider boxCollider in colliders)
                {
                    boxCollider.enabled = false;
                }
            }
        }


        if (motherboardObject != null && motherboardObject.GetComponent<MotherBoard>() && collider.gameObject.GetComponent<XRDirectInteractor>())
        {
            BoxCollider[] colliders = motherboardObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }
        }
    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == motherboardObject && motherboardObject != null)
        {
            BoxCollider[] colliders = motherboardObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in colliders)
            {
                boxCollider.enabled = true;
            }

            motherboardObject = null;

        }
    }
}

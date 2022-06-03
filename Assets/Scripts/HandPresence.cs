using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private List<InputDevice> devices = new List<InputDevice>();
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;
    public GameObject handPrefab;

    public GameObject spawnedHandPrefab;
    private Animator handAnimator;
   
    private void Start()
    {
        InitializeInputReader();
    }

    private void InitializeInputReader()
    {
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            spawnedHandPrefab = Instantiate(handPrefab, transform);
            handAnimator = spawnedHandPrefab.GetComponent<Animator>();
        }
    }

    private void UpdateHandAnimation()
    {
        if (spawnedHandPrefab != null)
        {
            if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                handAnimator.SetFloat("Trigger", triggerValue);
            }
            else
            {
                handAnimator.SetFloat("Trigger", 0);
            }

            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                handAnimator.SetFloat("Grip", gripValue);
            }
            else
            {
                handAnimator.SetFloat("Grip", 0);
            }

        }
    }


    private void Update()
    {
        if (devices.Count < 1)
        {
            InitializeInputReader();
        }

        UpdateHandAnimation();
    }
}

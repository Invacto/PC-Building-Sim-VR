using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Computer : MonoBehaviour
{
    ComputerParts computerParts;

    [SerializeField] private Canvas monitorScreen;
    private TextMeshProUGUI textMesh;
    private RawImage backgroundImage;

    public bool hasMotherboard;
    public bool hasCPU;
    public bool hasCPUFan;
    public bool hasMemory;
    public bool hasGPU;
    public bool hasPowersupply;
    public bool hasStorage;

    private bool displayedMissingMotherboard;
    private bool displayedMissingCPU;
    private bool displayedMissingCPUFan;
    private bool displayedMissingMemory;
    private bool displayedMissingGPU;
    private bool displayedMissingPSU;
    private bool displayedMissingStorage;

    private void Start()
    {
        computerParts = this.GetComponent<ComputerParts>();
        textMesh = monitorScreen.GetComponentInChildren<TextMeshProUGUI>();
        backgroundImage = monitorScreen.GetComponentInChildren<RawImage>();
    }
    private void FixedUpdate()
    {
        if (computerParts != null)
        {
            
            hasMotherboard = (computerParts.MotherBoard != null) ? true : false;

            hasCPU = (computerParts.CPU != null) ? true : false;

            hasCPUFan = (computerParts.CPUFan != null) ? true : false;

            hasPowersupply = (computerParts.PowerSupply != null) ? true : false;

            hasMemory = HasMemory();

            hasGPU = HasGPU();

            hasStorage = HasStorage();

            UpdateDisplay();

            if (hasMotherboard && hasCPU && hasCPUFan && hasMemory && hasGPU && hasPowersupply && hasStorage)
            {
                backgroundImage.enabled = true;
            }
            else
            {
                backgroundImage.enabled = false;
            }

        }
    }

    private void UpdateDisplay()
    {
        if (!hasMotherboard)
        {
            if (!displayedMissingMotherboard)
                textMesh.text += "Missing Motherboard.\n";

            displayedMissingMotherboard = true;
        }
        else
        {
            textMesh.text = textMesh.text.Replace("Missing Motherboard.\n", "");
            displayedMissingMotherboard = false;
        }

        if (!hasCPU)
        {
            if (!displayedMissingCPU)
                textMesh.text += "Missing Central Processing Unit.\n";

            displayedMissingCPU = true;
        }
        else
        {
            textMesh.text = textMesh.text.Replace("Missing Central Processing Unit.\n", "");
            displayedMissingCPU = false;
        }

        if (!hasCPUFan)
        {
            if (!displayedMissingCPUFan)
                textMesh.text += "Missing Central Processing Unit Fan.\n";

            displayedMissingCPUFan = true;
        }
        else
        {
            textMesh.text = textMesh.text.Replace("Missing Central Processing Unit Fan.\n", "");

            displayedMissingCPUFan = false;
        }

        if (!hasPowersupply)
        {
            if (!displayedMissingPSU)
                textMesh.text += "Missing Powersupply.\n";

            displayedMissingPSU = true;
        }
        else
        {
            textMesh.text = textMesh.text.Replace("Missing Powersupply.\n", "");
            displayedMissingPSU = false;
        }

        if (!hasMemory)
        {
            if (!displayedMissingMemory)
                textMesh.text += "Missing Memory.\n";

            displayedMissingMemory = true;
        }
        else
        {
            textMesh.text = textMesh.text.Replace("Missing Memory.\n", "");
            displayedMissingMemory = false;
        }

        if (!hasGPU)
        {
            if (!displayedMissingGPU)
                textMesh.text += "Missing Graphics Processing Unit.\n";

            displayedMissingGPU = true;
        }
        else
        {
            textMesh.text = textMesh.text.Replace("Missing Graphics Processing Unit.\n", "");

            displayedMissingGPU = false;
        }

        if (!hasStorage)
        {
            if (!displayedMissingStorage)
                textMesh.text += "Missing Storage.\n";

            displayedMissingStorage = true;
        }
        else
        {
            textMesh.text = textMesh.text.Replace("Missing Storage.\n", "");

            displayedMissingStorage = false;
        }
    }

    private bool HasMemory()
    {
        foreach (Memory ramStick in computerParts.Memory)
        {
            if (ramStick != null) return true;
        }

        return false;
    }

    private bool HasGPU()
    {
        foreach (GPU gpu in computerParts.GPUs)
        {
            if (gpu != null) return true;
        }

        return false;
    }

    private bool HasStorage()
    {
        foreach (HDD hdd in computerParts.HDDs)
        {
            if (hdd != null) return true;
        }

        foreach (SSD ssd in computerParts.SSDs)
        {
            if (ssd != null) return true;
        }

        return false;
    }
}

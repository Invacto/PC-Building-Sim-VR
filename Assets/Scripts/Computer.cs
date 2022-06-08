using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{

    [SerializeField] private PowerSupply _powerSupply;
    [SerializeField] private MotherBoard _motherBoard;
    [SerializeField] private CPU _cpu;
    [SerializeField] private CPUFan _cpuFan;
    [SerializeField] private GPU[] _gpus;
    [SerializeField] private Memory[] _memory;
    [SerializeField] private HDD[] _hdds;
    [SerializeField] private SSD[] _ssds;

    private Transform _slotsTransform;


    private void FixedUpdate()
    {
        _slotsTransform = this.transform.Find("Slots");

        if (!this.transform.Find("Slots"))
        {
            Debug.LogError("Parent of Slots Object must be named \"Slots\"");
        }

        if (_motherBoard != null)
            _motherBoard = _slotsTransform.GetComponentInChildren<GetMotherboard>().Motherboard.GetComponent<MotherBoard>();

        if (_powerSupply != null)
        _powerSupply = _slotsTransform.GetComponentInChildren<GetPSU>().PowerSupply.GetComponent<PowerSupply>();

        GetHDD[] hddScripts = _slotsTransform.GetComponentsInChildren<GetHDD>();

        if (hddScripts != null)
        {
            _hdds = new HDD[hddScripts.Length];

            for (int i = 0; i < _hdds.Length; i++)
            {
                if (hddScripts[i].HDD != null)
                    _hdds[i] = hddScripts[i].HDD.GetComponent<HDD>();
            }
        }

        GetSSD[] ssdScripts = _slotsTransform.GetComponentsInChildren<GetSSD>();

        if (ssdScripts != null)
        {
            _ssds = new SSD[ssdScripts.Length];

            for (int i = 0; i < _ssds.Length; i++)
            {
                if (ssdScripts[i].SSD != null)
                    _ssds[i] = ssdScripts[i].SSD.GetComponent<SSD>();
            }
        }

        if (_motherBoard != null)
        {
            Transform motherboardTransfrom = _motherBoard.gameObject.transform.Find("Slots");

            _cpu = motherboardTransfrom.GetComponentInChildren<GetCPU>().CPU.GetComponent<CPU>();
            _cpuFan = motherboardTransfrom.GetComponentInChildren<GetCPUFan>().CPUFan.GetComponent<CPUFan>();

            GetMemory[] memoryScripts = motherboardTransfrom.GetComponentsInChildren<GetMemory>();

            _memory = new Memory[memoryScripts.Length];

            for (int i = 0; i < _memory.Length; i++)
            {
                _memory[i] = memoryScripts[i].Memory.GetComponent<Memory>();
            }

            GetGPU[] gpuScripts = motherboardTransfrom.GetComponentsInChildren<GetGPU>();

            _gpus = new GPU[gpuScripts.Length];

            for (int i = 0; i < _gpus.Length; i++)
            {
                _gpus[i] = gpuScripts[i].GPU.GetComponent<GPU>();
            }
        }

        

    }

}

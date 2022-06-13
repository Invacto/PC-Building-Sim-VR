using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerParts : MonoBehaviour
{

    [SerializeField] private PowerSupply _powerSupply;
    [SerializeField] private MotherBoard _motherBoard;
    [SerializeField] private CPU _cpu;
    [SerializeField] private CPUFan _cpuFan;
    [SerializeField] private GPU[] _gpus;
    [SerializeField] private Memory[] _memory;
    [SerializeField] private HDD[] _hdds;
    [SerializeField] private SSD[] _ssds;

    public PowerSupply PowerSupply { get { return _powerSupply; } }
    public MotherBoard MotherBoard { get { return _motherBoard; } }
    public CPU CPU { get { return _cpu; } }
    public CPUFan CPUFan { get { return _cpuFan; } }
    public GPU[] GPUs { get { return _gpus; } }
    public Memory[] Memory { get { return _memory; } }
    public HDD[] HDDs { get { return _hdds; } }
    public SSD[] SSDs { get { return _ssds; } }

    private Transform _slotsTransform;

    private void FixedUpdate()
    {
        _slotsTransform = this.transform.Find("Slots");

        if (!this.transform.Find("Slots"))
        {
            Debug.LogError("Parent of Slots Object must be named \"Slots\"");
        }

        _motherBoard = (_slotsTransform.GetComponentInChildren<GetMotherboard>().Motherboard != null) ?
            _motherBoard = _slotsTransform.GetComponentInChildren<GetMotherboard>().Motherboard.GetComponent<MotherBoard>() : null;

        _powerSupply = (_slotsTransform.GetComponentInChildren<GetPSU>().PowerSupply != null) ?
            _powerSupply = _slotsTransform.GetComponentInChildren<GetPSU>().PowerSupply.GetComponent<PowerSupply>() : null;

        GetHDD[] hddScripts = _slotsTransform.GetComponentsInChildren<GetHDD>();
        _hdds = new HDD[hddScripts.Length];

        for (int i = 0; i < hddScripts.Length; i++)
        {
            _hdds[i] = (hddScripts[i].HDD != null) ?
                _hdds[i] = hddScripts[i].HDD.GetComponent<HDD>() : null;
        }

        GetSSD[] ssdScripts = _slotsTransform.GetComponentsInChildren<GetSSD>();
        _ssds = new SSD[ssdScripts.Length];

        for (int i = 0; i < ssdScripts.Length; i++)
        {
            _ssds[i] = (ssdScripts[i].SSD != null) ?
                _ssds[i] = ssdScripts[i].SSD.GetComponent<SSD>() : null;
        }

        if (_motherBoard != null)
        {
            Transform motherboardTransfrom = _motherBoard.gameObject.transform.Find("Slots");

            _cpu = (motherboardTransfrom.GetComponentInChildren<GetCPU>().CPU != null) ?
                _cpu = motherboardTransfrom.GetComponentInChildren<GetCPU>().CPU.GetComponent<CPU>() : null;

            _cpuFan = (motherboardTransfrom.GetComponentInChildren<GetCPUFan>().CPUFan != null) ?
                _cpuFan = motherboardTransfrom.GetComponentInChildren<GetCPUFan>().CPUFan.GetComponent<CPUFan>() : null;

            GetMemory[] memoryScripts = motherboardTransfrom.GetComponentsInChildren<GetMemory>();
            _memory = new Memory[memoryScripts.Length];

            for (int i = 0; i < _memory.Length; i++)
            {
                _memory[i] = (memoryScripts[i].Memory != null) ?
                    _memory[i] = memoryScripts[i].Memory.GetComponent<Memory>() : null;
            }

            GetGPU[] gpuScripts = motherboardTransfrom.GetComponentsInChildren<GetGPU>();
            _gpus = new GPU[gpuScripts.Length];

            for (int i = 0; i < _gpus.Length; i++)
            {
                _gpus[i] = (gpuScripts[i].GPU != null) ?
                    _gpus[i] = gpuScripts[i].GPU.GetComponent<GPU>() : null;
            }
        }
        else
        {
            _cpu = null;
            _cpuFan = null;

            for (int i = 0; i < _memory.Length; i++)
            {
                _memory[i] = null;
            }

            for (int i = 0; i < _gpus.Length; i++)
            {
                _gpus[i] = null; 
            }
        }

        

    }

    



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBoard : MonoBehaviour
{
    [SerializeField] private string _name; 
    [SerializeField] private MotherBoardSize _motherBoardSize;
    [SerializeField] private Socket _socket;
    [SerializeField] private CPU _cpu;
    [SerializeField] private CPU _cpuFan;
    [SerializeField] private int _memorySlots;
    [SerializeField] private Memory[] _memory;
    [SerializeField] private GPULane _gpuLane;
    [SerializeField] private int _gpuSlots;
    [SerializeField] private GPU[] _gpus;
    [SerializeField] private int _wattage;

    public string Name { get { return _name; } }
    public MotherBoardSize MotherBoardSize { get { return _motherBoardSize; } }
    public Socket Socket { get { return _socket; } }
    public CPU CPU { get { return _cpu; } }
    public CPU CPUFan { get { return _cpuFan; } }
    public int MemorySlots { get { return _memorySlots; } }
    public Memory[] MemorySticks { get { return _memory; } }
    public GPULane GPULane { get { return _gpuLane; } }
    public int GPUSlots { get { return _gpuSlots; } }
    public GPU[] GPUs { get { return _gpus; } }
    public int Wattage { get { return _wattage; } }

    void Start() 
    {
        _memorySlots = 4;
        _gpuSlots = 1;

        _memory = new Memory[_memorySlots];
    }

    public bool InsertCPU(CPU cpu) 
    {
        if (cpu.Socket == _socket) 
        {
            _socket = cpu.Socket;

            return true;
        }

        return false;
    }

    public bool InsertCPUFan(CPU cpuFan)
    {

        _cpuFan = cpuFan;

        return true;
    }

    public bool InsertMemoryInSlot(Memory memory, int slot) 
    {
        if (_memory[slot] == null) 
        {
            _memory[slot] = memory;

            return true;
        }

        return false;

    }

    public bool InsertGPU(GPU gpu, int slot) 
    {
        if (_gpus[slot] == null) 
        {
            _gpus[slot] = gpu;

            return true;
        }

        return false;
    }
}

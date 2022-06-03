using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private MotherBoardSize _motherBoardSize;
    [SerializeField] private MotherBoard _motherBoard;
    [SerializeField] private PowerSupply _powerSupply;
    [SerializeField] private int _storageSlots;
    [SerializeField] private Storage[] _storage;
    [SerializeField] private int _fanSlots;
    [SerializeField] private Fan[] _fans;

    public string Name { get { return _name; } }
    public MotherBoardSize MotherBoardSize { get { return _motherBoardSize; } }
    public MotherBoard MotherBoard { get { return _motherBoard; } }
    public PowerSupply PowerSupply { get { return _powerSupply; } }
    public int StorageSlots { get { return _storageSlots; } }
    public Storage[] Storages { get { return _storage; } }
    public int FanSlots { get { return _fanSlots; } }
    public Fan[] Fans { get { return _fans; } } 


    public void Start() 
    {
        _storageSlots = 4;
        _fanSlots = 4;

        _storage = new Storage[_storageSlots];
        _fans = new Fan[_fanSlots];
    }

    public void Update()
    {

    }

    public bool InsertMotherBoard(MotherBoard motherBoard) 
    {
        if (motherBoard.MotherBoardSize == _motherBoardSize) 
        {
            _motherBoard = motherBoard;

            return true;
        }  

        return false;
    }

    public bool InsertPowerSupply(PowerSupply powerSupply) 
    {
        _powerSupply = powerSupply;

        return true;
    }

    public bool InsertStorageInSlot(Storage storage, int slot) 
    {
        if (_storage[slot] == null)
        {
            _storage[slot] = storage;

            return true;
        }

        return false;
    }

    public bool InsertFanInSlot(Fan fan, int slot) 
    {
        if (_fans[slot] == null) 
        {
            _fans[slot] = fan;

            return true;
        }

        return false;
    }
    
}

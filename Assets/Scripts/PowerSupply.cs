using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSupply : MonoBehaviour
{
    [SerializeField] private string _name { get; }
    [SerializeField] private int _wattage { get; }

    public string Name { get { return _name; } }
    public int Wattage { get { return _wattage; } }
}

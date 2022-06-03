using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    [SerializeField] private string _name; 
    [SerializeField] private Socket _socket; 
    [SerializeField] private int _wattage;

    public string Name { get { return _name; } } 
    public Socket Socket { get { return _socket; } }
    private int Wattage { get { return _wattage; } }
}

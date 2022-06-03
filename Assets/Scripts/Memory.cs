using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    [SerializeField] private string _name { get; }
    [SerializeField] private int _memorySize { get; }

    public string Name { get { return _name; } }
    public int MemorySize { get { return _memorySize; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUFan : MonoBehaviour
{
    [SerializeField] private string _name;

    public string Name { get { return _name; } }
}

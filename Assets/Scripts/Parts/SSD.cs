using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSD : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _gigabytes;

    public string Name { get { return _name; } }
    public int Gigabytes { get { return _gigabytes; } }
}

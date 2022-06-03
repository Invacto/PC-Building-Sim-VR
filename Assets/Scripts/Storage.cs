using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private string _name { get; }
    [SerializeField] private int _gigabytes { get; }

    public string Name { get { return _name; } }
    public int Gigabytes { get { return _gigabytes; } }
}

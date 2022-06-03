using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU : MonoBehaviour
{
   [SerializeField] private string _name { get; } 
   [SerializeField] private GPULane _gpuLane;
   [SerializeField] private int _wattage { get; }

   public string Name { get { return _name; } }
   public GPULane GPULane { get { return _gpuLane; } }
   public int Wattage { get { return _wattage; } }
}

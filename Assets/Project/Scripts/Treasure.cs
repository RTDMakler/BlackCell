using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private string _name;
    public string Name { get 
        { return this._name; } }  

    [SerializeField] private float cost;
    public float Cost { get 
        { return this.cost; } }

    [SerializeField] private float weight;
    public float Weight { get 
        { return this.weight; } }

    private void Start()
    {
        if (Cost == 0)
        cost =Random.Range(10, 1000);
        if (Weight == 0)
        weight = Random.Range(5, 100);
    }
}

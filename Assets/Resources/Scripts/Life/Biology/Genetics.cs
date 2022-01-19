using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genetics : MonoBehaviour
{
    ResourceStorageController resources;
    void Start()
    {
        resources = GetComponentInChildren<ResourceStorageController>();
    }

    public void GainDNA(float _amount)
    {
        resources.DNA.AddTo(_amount);
    }

    public void SpendDNA(float _amount)
    {
        resources.DNA.TakeFrom(_amount);
    }

    public float GetDNA()
    {
        return resources.DNA.current;
    }
}

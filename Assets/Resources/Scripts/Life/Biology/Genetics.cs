using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genetics : MonoBehaviour
{
    ResourceStorageController Resources;
    void Start()
    {
        Resources = GetComponentInChildren<ResourceStorageController>();
    }

    public void GainDNA(float _amount)
    {
        Resources.DNA.AddTo(_amount);
    }

    public void SpendDNA(float _amount)
    {
        Resources.DNA.TakeFrom(_amount);
    }

    public float GetDNA()
    {
        return Resources.DNA.current;
    }
}

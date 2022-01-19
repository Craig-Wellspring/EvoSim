using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digester : MonoBehaviour
{
    public float rate = 1f;

    public float energyReturn = 2f;

    public float energyCost = 0.5f;

    [HideInInspector]
    public ResourceStorageController resources;

    void Start()
    {
        resources =
            transform.root.GetComponentInChildren<ResourceStorageController>();
    }

    public virtual bool ConsumeResource(float _rate)
    {
        return false;
    }

    public void Digest()
    {
        if (resources.Energy.TakeFrom(energyCost))
        {
            if (ConsumeResource(rate)) resources.Energy.AddTo(energyReturn);
        }
    }
}

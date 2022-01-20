using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digester : MonoBehaviour
{
    public float rate = 1f;
    public float energyCost = 0.5f;

    [HideInInspector]
    public ResourceStorageController resources;

    void Start()
    {
        resources =
            transform.root.GetComponentInChildren<ResourceStorageController>();
    }

    // Consume {_rate} resources in exchange for {return} Energy
    public virtual float MetabolizeResource(float _rate)
    {
        return 0f;
    }

    public void Digest()
    {
        if (resources.Energy.TakeFrom(energyCost))
        {
            float energyGenerated = MetabolizeResource(rate);
            if (energyGenerated > 0) resources.Energy.AddTo(energyGenerated);
        }
    }
}

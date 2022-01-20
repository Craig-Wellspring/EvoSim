using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Membrane : Hull
{
    [Tooltip("Water absorbed per second")]
    public float osmosisRate = 5f;

    HullType hullType = HullType.Membrane;

    ResourceType type = ResourceType.Water;

    ResourceStorageController resources;

    void Start()
    {
        resources =
            transform.root.GetComponentInChildren<ResourceStorageController>();
    }

    void Update()
    {
        resources.Water.AddTo(osmosisRate * Time.deltaTime);
    }
}

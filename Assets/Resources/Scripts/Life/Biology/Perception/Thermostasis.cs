using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermostasis : MonoBehaviour
{
    public float heatChange;

    [Range(0, 100)]
    public float heatLevel;

    [Range(0, 100)]
    public float insulation = 0f;

    float damper = 10f;

    float oceanDepth = 100;

    ResourceStorageController resources;

    void Start()
    {
        resources =
            transform.GetComponentInChildren<ResourceStorageController>();
    }

    void RegulateHeat()
    {
        heatChange =
            (
            ((heatLevel * (1 - (insulation / 100))) - (oceanDepth / 2)) / damper
            ) *
            Time.deltaTime;

        if (heatChange > 0)
        {
            if (resources.Heat.AddTo(heatChange) > 0)
            {
                // Overheat
            }
        }
        else
        {
            if (!resources.Heat.TakeFrom(-heatChange))
            {
                // Frozen
            }

        }
    }

    void Update()
    {
        heatLevel = transform.root.position.y;
        RegulateHeat();
    }
}

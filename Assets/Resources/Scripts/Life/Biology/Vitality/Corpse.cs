using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    [HideInInspector]
    public Resource Flesh, Pulp, Mineral;

    void AssignResources()
    {
        Resource[] allResources = GetComponents<Resource>();
        foreach (Resource resource in allResources)
        {
            switch (resource.type)
            {
                case ResourceType.Flesh: Flesh = resource; break;
                case ResourceType.Pulp: Pulp = resource; break;
                case ResourceType.Mineral: Mineral = resource; break;
            }
        }
    }

    void Awake()
    {
        AssignResources();
    }
}

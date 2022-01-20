using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    None,
    Heat,
    Water,
    Flesh,
    Pulp,
    Mineral,
    Oxygen,
    Energy,
    Health,
    Stamina,
    Focus,
    DNA
}

public class ResourceStorageController : MonoBehaviour
{
    [HideInInspector]
    public ResourceManager

            Energy,
            Health,
            Stamina,
            Focus,
            Oxygen,
            Water,
            Heat,
            Flesh,
            Pulp,
            Mineral,
            DNA;

    void AssignResources()
    {
        ResourceManager[] allResources = GetComponents<ResourceManager>();
        foreach (ResourceManager manager in allResources)
        {
            switch (manager.type)
            {
                case ResourceType.Health:
                    Health = manager;
                    break;
                case ResourceType.Stamina:
                    Stamina = manager;
                    break;
                case ResourceType.Focus:
                    Focus = manager;
                    break;
                case ResourceType.Energy:
                    Energy = manager;
                    break;
                case ResourceType.Heat:
                    Heat = manager;
                    break;
                case ResourceType.Oxygen:
                    Oxygen = manager;
                    break;
                case ResourceType.Water:
                    Water = manager;
                    break;
                case ResourceType.Flesh:
                    Flesh = manager;
                    break;
                case ResourceType.Pulp:
                    Pulp = manager;
                    break;
                case ResourceType.Mineral:
                    Mineral = manager;
                    break;
                case ResourceType.DNA:
                    DNA = manager;
                    break;
            }
        }
    }

    void Awake()
    {
        AssignResources();
    }
}

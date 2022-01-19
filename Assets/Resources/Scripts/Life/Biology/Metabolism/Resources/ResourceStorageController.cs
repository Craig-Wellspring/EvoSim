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
    [HideInInspector] public ResourceManager Energy, Health, Stamina, Focus, Oxygen, Water, Heat, Flesh, Pulp, Mineral, DNA;
    void Start()
    {
        Health = gameObject.AddComponent<ResourceManager>();
        Health.Initialize(ResourceType.Health, true);
        
        Stamina = gameObject.AddComponent<ResourceManager>();
        Stamina.Initialize(ResourceType.Stamina);

        Focus = gameObject.AddComponent<ResourceManager>();
        Focus.Initialize(ResourceType.Focus);

        Energy = gameObject.AddComponent<ResourceManager>();
        Energy.Initialize(ResourceType.Energy, true);

        Heat = gameObject.AddComponent<ResourceManager>();
        Heat.Initialize(ResourceType.Heat);

        Oxygen = gameObject.AddComponent<ResourceManager>();
        Oxygen.Initialize(ResourceType.Oxygen);

        Water = gameObject.AddComponent<ResourceManager>();
        Water.Initialize(ResourceType.Water);

        Flesh = gameObject.AddComponent<ResourceManager>();
        Flesh.Initialize(ResourceType.Flesh);

        Pulp = gameObject.AddComponent<ResourceManager>();
        Pulp.Initialize(ResourceType.Pulp);

        Mineral = gameObject.AddComponent<ResourceManager>();
        Mineral.Initialize(ResourceType.Mineral);

        DNA = gameObject.AddComponent<ResourceManager>();
        DNA.Initialize(ResourceType.DNA);
    }
}

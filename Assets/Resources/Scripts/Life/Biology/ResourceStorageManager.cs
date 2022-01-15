using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStorageManager : MonoBehaviour
{
    [HideInInspector] public ResourceStorage Energy, Health, Stamina, Focus, Oxygen, Water, Light, Heat, Flesh, Pulp, Mineral;
    void Start()
    {
        Energy = gameObject.AddComponent<ResourceStorage>();
        Energy.SetValues(ResourceType.Energy, 100, 100);

        Health = gameObject.AddComponent<ResourceStorage>();
        Health.SetValues(ResourceType.Health, 2, 2);      
    }
}

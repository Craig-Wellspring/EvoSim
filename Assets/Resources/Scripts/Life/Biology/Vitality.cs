using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    ResourceStorageController resources;

    CentralNervousSystem CNS;

    GameObject corpse;

    public bool isAlive = true;

    void Start()
    {
        resources = GetComponentInChildren<ResourceStorageController>();
        CNS = GetComponentInParent<CentralNervousSystem>();
        corpse = transform.root.GetComponentInChildren<Corpse>().gameObject;
    }

    public bool TakeDamage(float _amount)
    {
        if (resources.Health.TakeFrom(_amount, 1))
        {
            return true;
        }
        else
        {
            Die();
            return false;
        }
    }

    public float Heal(float _increase)
    {
        return resources.Health.AddTo(_increase);
    }

    public float GetCurrentHealth()
    {
        return resources.Health.current;
    }

    public bool isMaxHealth()
    {
        return resources.Health.current >= resources.Health.max;
    }

    void Die()
    {
        resources.Health.Set(0f);
        isAlive = false;
        CNS.metabolism.enabled = false;
        corpse.SetActive(true);
    }
}

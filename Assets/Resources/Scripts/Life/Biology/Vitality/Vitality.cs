using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    ResourceStorageController resources;

    CentralNervousSystem CNS;

    Corpse corpse;

    [Range(0, 100)]
    public float regenRate = 1f;

    public bool isAlive = true;

    void Start()
    {
        resources = GetComponentInChildren<ResourceStorageController>();
        CNS = GetComponentInParent<CentralNervousSystem>();
        corpse = transform.root.GetComponentInChildren<Corpse>(true);
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

    public float Regenerate()
    {
        return Heal(regenRate / 100);
    }

    public float GetCurrentHealth()
    {
        return resources.Health.current;
    }

    public bool isMaxHealth()
    {
        return resources.Health.current >= resources.Health.max;
    }

    void TransferResourcesToCorpse()
    {
        if (resources.Flesh.current > 0)
        {
            corpse.Flesh.remaining = resources.Flesh.current;
            resources.Flesh.Set(0);
        }
        if (resources.Pulp.current > 0)
        {
            corpse.Pulp.remaining = resources.Pulp.current;
            resources.Pulp.Set(0);
        }
        if (resources.Mineral.current > 0)
        {
            corpse.Mineral.remaining = resources.Mineral.current;
            resources.Mineral.Set(0);
        }
        if (resources.Energy.current > 0)
        {
            float highestStorage =
                Mathf
                    .Max(resources.Flesh.max,
                    (Mathf.Max(resources.Pulp.max, resources.Mineral.max)));
            if (highestStorage == resources.Flesh.max)
            {
                corpse.Flesh.remaining += resources.Energy.current / 2;
                resources.Energy.Set(0);
                return;
            }
            else if (highestStorage == resources.Pulp.max)
            {
                corpse.Pulp.remaining += resources.Energy.current / 2;
                resources.Energy.Set(0);
                return;
            }
            else if (highestStorage == resources.Mineral.max)
            {
                corpse.Mineral.remaining += resources.Energy.current / 2;
                resources.Energy.Set(0);
                return;
            }
        }
    }

    void Die()
    {
        // Disable life functions
        resources.Health.Set(0f);
        isAlive = false;
        CNS.metabolism.enabled = false;

        // Enable corpse
        corpse.gameObject.SetActive(true);
        TransferResourcesToCorpse();
    }
}

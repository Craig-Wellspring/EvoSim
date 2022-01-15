using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    ResourceStorageManager Resources;

    void Start()
    {
        Resources = GetComponentInChildren<ResourceStorageManager>();
    }

    public void TakeDamage(float _amount)
    {
        if (!Resources.Health.takeFrom(_amount))
        {
            Die();
        }
    }

    public float Heal(float _increase)
    {
        return Resources.Health.addTo(_increase);
    }


    public float GetCurrentHealth()
    {
        return Resources.Health.current;
    }

    void Die()
    {
    }
}

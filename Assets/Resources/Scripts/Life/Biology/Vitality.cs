using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    ResourceStorageController Resources;
    CentralNervousSystem CNS;

    public bool isAlive = true;

    void Start()
    {
        Resources = GetComponentInChildren<ResourceStorageController>();
        CNS = GetComponentInParent<CentralNervousSystem>();
    }

    public bool TakeDamage(float _amount)
    {
        if (!Resources.Health.TakeFrom(_amount, 1))
        {
            Die();
            return false;
        }
        return true;
    }

    public float Heal(float _increase)
    {
        return Resources.Health.AddTo(_increase);
    }

    public float GetCurrentHealth()
    {
        return Resources.Health.current;
    }

    public bool isMaxHealth()
    {
        return Resources.Health.current >= Resources.Health.max;
    }

    void Die()
    {
        Resources.Health.Set(0f);
        isAlive = false;
        CNS.Metabolism.enabled = false;
    }
}

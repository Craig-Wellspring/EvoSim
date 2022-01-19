using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : MonoBehaviour
{
    [Range(0, 100)]
    public float metabolicEfficiency = 20;

    public float metabolismRate = 1;

    float metaTick = 0;

    ResourceStorageController resources;

    CentralNervousSystem CNS;

    void Start()
    {
        resources = GetComponentInChildren<ResourceStorageController>();
        CNS = GetComponentInParent<CentralNervousSystem>();
    }

    float CalculateFoodStorage()
    {
        float stored = 0f;
        stored += resources.Flesh.current;
        stored += resources.Pulp.current;
        return stored;
    }

    float Regenerate()
    {
        return CNS.vitality.Heal(0.01f);
    }

    void Atrophy()
    {
        if (CNS.vitality.TakeDamage(1))
        {
            resources.Energy.AddTo(metabolicEfficiency - 1);
        }
    }

    void Metabolize()
    {
        // DIGEST FOOD
        if (CalculateFoodStorage() > 0)
        {
            if (resources.Flesh.current > resources.Pulp.current)
            {
                resources.Flesh.TakeFrom(1);
            }
            else
            {
                resources.Pulp.TakeFrom(1);
            }
            resources.Energy.AddTo(2);
        }

        // CONSUME ENERGY
        if (resources.Energy.TakeFrom(1))
        {
            if (resources.Energy.TakeFrom(1))
            {
                if (CNS.vitality.isMaxHealth())
                {
                    CNS.genetics.GainDNA(1);
                }
                else
                {
                    Regenerate();
                }
            }
        } // TRADE HEALTH FOR ENERGY
        else
        {
            Atrophy();
        }
    }

    // METABOLIC LOOP
    void Update()
    {
        metaTick += Time.deltaTime;
        if (metaTick > metabolismRate)
        {
            metaTick = 0;
            Metabolize();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : MonoBehaviour
{
    [Range(0, 100)]
    public float metabolicEfficiency = 20;

    public float metabolismRate = 1;

    float metaTick = 0;

    ResourceStorageController Resources;

    CentralNervousSystem CNS;

    void Start()
    {
        Resources = GetComponentInChildren<ResourceStorageController>();
        CNS = GetComponentInParent<CentralNervousSystem>();
    }

    float Regenerate()
    {
        return CNS.Vitality.Heal(0.01f);
    }

    void Atrophy()
    {
        if (CNS.Vitality.TakeDamage(1))
        {
            Resources.Energy.AddTo(metabolicEfficiency - 1);
        }
    }

    void Metabolize()
    {
        if (Resources.Energy.TakeFrom(1))
        {
            if (CNS.Vitality.isMaxHealth())
            {
                CNS.Genetics.GainDNA(1);
            } else {
                Regenerate();
            }
        }
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

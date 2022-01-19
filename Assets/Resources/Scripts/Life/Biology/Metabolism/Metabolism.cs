using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : MonoBehaviour
{
    [Range(0, 100)]
    public float metabolicEfficiency = 20f;
    public float maintenanceCost = 1f;

    public float metabolismRate = 1f;

    float metaTick = 0f;

    ResourceStorageController resources;

    CentralNervousSystem CNS;

    Digester[] digesters;

    void Start()
    {
        resources = GetComponentInChildren<ResourceStorageController>();
        CNS = GetComponentInParent<CentralNervousSystem>();
        RegisterDigesters();
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

    void RegisterDigesters()
    {
        digesters = transform.root.GetComponentsInChildren<Digester>();
    }

    void Metabolize()
    {
        // DIGEST FOOD
        foreach (Digester digester in digesters)
        {
            digester.Digest();
        }

        // CONSUME ENERGY
        if (resources.Energy.TakeFrom(maintenanceCost))
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

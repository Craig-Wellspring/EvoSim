using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : MonoBehaviour
{
    [Range(0, 100)]
    public float metabolicEfficiency = 20f;

    public float maintenanceCost = 0.5f;

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
            if (!CNS.vitality.isMaxHealth())
            {
                if (resources.Energy.TakeFrom(1)) CNS.vitality.Regenerate();
            }
            // if !isMaxStam, trade energy for stam

            if (resources.Energy.TakeFrom(1)) CNS.genetics.GainDNA(1);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : MonoBehaviour
{
    public float metabolicEfficiency = 20;

    public float metabolismRate = 250;

    float metaTick = 0;

    ResourceStorageManager Resources;

    Vitality Vitality;

    void Start()
    {
        Resources = GetComponentInChildren<ResourceStorageManager>();
        Vitality = GetComponent<Vitality>();
    }

    float Regenerate()
    {
        return Vitality.Heal(0.01f);
    }

    void Metabolize()
    {
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

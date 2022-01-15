using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : MonoBehaviour
{
    public int metabolicEfficiency = 20;
    public int metabolismRate = 250;
    int metaTick = 0;

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


    // METABOLIC LOOP
    void Update()
    {
    }
}

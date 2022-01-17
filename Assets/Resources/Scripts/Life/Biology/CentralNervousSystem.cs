using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralNervousSystem : MonoBehaviour
{
    [HideInInspector] public Vitality Vitality;
    [HideInInspector] public Metabolism Metabolism;
    [HideInInspector] public Genetics Genetics;

    void Start()
    {
        Vitality = GetComponentInChildren<Vitality>();
        Metabolism = GetComponentInChildren<Metabolism>();
        Genetics = GetComponentInChildren<Genetics>();
    }
}

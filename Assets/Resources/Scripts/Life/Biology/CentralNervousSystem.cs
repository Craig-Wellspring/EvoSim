using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralNervousSystem : MonoBehaviour
{
    [HideInInspector] public Vitality vitality;
    [HideInInspector] public Metabolism metabolism;
    [HideInInspector] public Genetics genetics;

    void Start()
    {
        vitality = GetComponentInChildren<Vitality>();
        metabolism = GetComponentInChildren<Metabolism>();
        genetics = GetComponentInChildren<Genetics>();
    }
}

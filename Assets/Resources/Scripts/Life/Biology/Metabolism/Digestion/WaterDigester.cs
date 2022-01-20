using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDigester : Digester
{
    LightSense lightSense;

    void Start()
    {
        lightSense = transform.root.GetComponentInChildren<LightSense>();
    }

    public override float MetabolizeResource(float _rate)
    {
        if (resources.Water.current >= _rate && lightSense.sensed > 0)
        {
            float adjustedRate = _rate * lightSense.sensed;
            resources.Water.TakeFrom (adjustedRate);
            resources.Oxygen.AddTo (adjustedRate);
            return adjustedRate;
        }
        else
        {
            return 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDigester : Digester
{
    [Range(0f, 1f)]
    public float lightRequired = 0.3f;
    LightLevel lightSense;

    void Start(){
        lightSense = transform.root.GetComponentInChildren<LightLevel>();
    }

    public override bool ConsumeResource(float _rate)
    {
        if (resources.Water.current >= _rate && lightSense.level >= lightRequired)
        {
            resources.Water.TakeFrom(_rate);
            resources.Oxygen.AddTo(_rate);
            return true;
        }
        else
        {
            return false;
        }
    }
}

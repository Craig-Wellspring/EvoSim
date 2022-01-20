using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshDigester : Digester
{
    public float efficiency = 2f;
    
    public override float MetabolizeResource(float _rate)
    {
        float energyGenerated = 0f;
        if (resources.Flesh.TakeFrom(_rate)) energyGenerated = _rate * efficiency;
        return energyGenerated;
    }
}

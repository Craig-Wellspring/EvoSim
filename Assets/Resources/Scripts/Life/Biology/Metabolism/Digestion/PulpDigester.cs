using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpDigester : Digester
{
    public float efficiency = 2f;

    public override float MetabolizeResource(float _rate)
    {
        float energyGenerated = 0f;
        if (resources.Pulp.TakeFrom(_rate)) energyGenerated = _rate * efficiency;
        return energyGenerated;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralDigester : Digester
{
    public float efficiency = 2f;

    public override float MetabolizeResource(float _rate)
    {
        float energyGenerated = 0f;
        if (
            resources.Mineral.current >= _rate &&
            resources.Oxygen.current >= _rate
        )
        {
            resources.Mineral.TakeFrom (_rate);
            resources.Oxygen.TakeFrom (_rate);
            energyGenerated = _rate * efficiency;
        }
        return energyGenerated;
    }
}

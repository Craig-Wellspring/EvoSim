using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralDigester : Digester
{
    public override bool ConsumeResource(float _rate)
    {
        if (resources.Mineral.current >= _rate && resources.Oxygen.current >= _rate)
        {
            resources.Mineral.TakeFrom(_rate);
            resources.Oxygen.TakeFrom(_rate);
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpDigester : Digester
{
    public override bool ConsumeResource(float _rate)
    {
        return resources.Pulp.TakeFrom(_rate);
    }
}

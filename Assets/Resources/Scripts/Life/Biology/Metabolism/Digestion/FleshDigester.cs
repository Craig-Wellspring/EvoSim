using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshDigester : Digester
{
    public override bool ConsumeResource(float _rate)
    {
        return resources.Flesh.TakeFrom(_rate);
    }
}

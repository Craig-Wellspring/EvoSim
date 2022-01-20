using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
}

public enum HullType
{
    Membrane, // Water, Contact osmosis
    Skin, // Flesh
    Scale, // Mineral - Malleable
    Shell, // Mineral - Rigid
    Cuticle, // Pulp - Malleable
    Bark // Pulp - Rigid
}

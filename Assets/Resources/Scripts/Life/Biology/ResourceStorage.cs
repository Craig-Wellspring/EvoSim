using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    None,
    Heat,
    Light,
    Water,
    Flesh,
    Pulp,
    Mineral,
    Oxygen,
    Energy,
    Health,
    Stamina,
    Focus,
    DNA
}

public class ResourceStorage : MonoBehaviour
{
    public void SetValues(ResourceType _type, float _current, float _max)
    {
        Type = _type;
        current = _current;
        max = _max;
    }

    public ResourceType Type;

    public float current;

    public float max;

    public float addTo(float _increase)
    {
        if (current + _increase < max)
        {
            current += _increase;
            return 0;
        }
        else
        {
            float excess = current + _increase - max;
            current = max;
            return excess;
        }
    }

    public bool takeFrom(float _decrease)
    {
        if (current - _decrease > 0)
        {
            current -= _decrease;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CalculateMax()
    {
        // maxStorage = maxStorage;
    }
}

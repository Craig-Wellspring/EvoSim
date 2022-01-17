using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
  public ResourceType Type;
  public float remaining;

  public void Initialize(ResourceType _type, float _remaining)
  {
    Type = _type;
    remaining = _remaining;
  }

  public float AddTo(float _increase)
  {
    remaining += _increase;
    return remaining;
  }

  public float TakeFrom(float _decrease, float _min = 0f)
  {
    if (remaining - _decrease >= _min)
    {
      remaining -= _decrease;
      return _decrease;
    }
    else
    {
      float available = remaining;
      remaining = 0;
      return available;
    }
  }

  public float TakeAll()
  {
    float available = remaining;
    remaining = 0;
    return available;
  }

  public void Set(float _amount)
  {
    remaining = _amount;
  }
}

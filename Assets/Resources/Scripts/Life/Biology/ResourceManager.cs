using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
  public ResourceType Type;

  public float current;

  public float max;

  bool startMax = false;

  public void Initialize(ResourceType _type, bool _startMax = false, float _current = 0, float _max = 0)
  {
    Type = _type;
    startMax = _startMax;
    current = _current;
    max = _max;
  }

  public float AddTo(float _increase)
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

  public bool TakeFrom(float _decrease, float _min = 0f)
  {
    if (current - _decrease >= _min)
    {
      current -= _decrease;
      return true;
    }
    else
    {
      return false;
    }
  }

  public void Set(float _amount)
  {
    current = _amount;
  }

  void SetMax(float _value)
  {
    max = _value;
    if (current > max) current = max;
  }

  public float CalculateMax()
  {
    float calculatedMax = 0f;
    ResourceStorage[] storageCells = transform.root.GetComponentsInChildren<ResourceStorage>();
    foreach (var cell in storageCells)
    {
      if (cell.Type == this.Type)
      {
        calculatedMax += cell.increaseMaxStorage;
      }
    }
    SetMax(calculatedMax);

    return calculatedMax;
  }

  void Start()
  {
    CalculateMax();
    if (startMax) current = max;
  }
}

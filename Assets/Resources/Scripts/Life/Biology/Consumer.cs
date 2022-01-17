using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
  public ResourceType Type;
  [HideInInspector] ResourceManager Storage;
  [HideInInspector] ResourceStorageController StorageController;

  void Start()
  {
    AssignManager();
  }

  public void Initialize(ResourceType _type)
  {
    Type = _type;
    AssignManager();
  }

  void AssignManager()
  {
    switch (Type)
    {
      case ResourceType.Flesh: Storage = StorageController.Flesh; break;
      case ResourceType.Pulp: Storage = StorageController.Pulp; break;
      case ResourceType.Mineral: Storage = StorageController.Mineral; break;
      case ResourceType.Water: Storage = StorageController.Water; break;
    }
  }

  public void Consume(Resource _target, float _amount)
  {
    if (_target.Type == Type && _target.remaining > 0)
    {
      Storage.AddTo(_target.TakeFrom(_amount));
    }
  }
}

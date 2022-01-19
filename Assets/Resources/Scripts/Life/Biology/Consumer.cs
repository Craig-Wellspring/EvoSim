using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
  public ResourceType type;
  [HideInInspector] ResourceManager storage;
  [HideInInspector] ResourceStorageController storageController;

  void Start()
  {
    AssignManager();
  }

  public void Initialize(ResourceType _type)
  {
    type = _type;
    AssignManager();
  }

  void AssignManager()
  {
    switch (type)
    {
      case ResourceType.Flesh: storage = storageController.Flesh; break;
      case ResourceType.Pulp: storage = storageController.Pulp; break;
      case ResourceType.Mineral: storage = storageController.Mineral; break;
      case ResourceType.Water: storage = storageController.Water; break;
    }
  }

  public void Consume(Resource _target, float _amount)
  {
    if (_target.type == type && _target.remaining > 0)
    {
      storage.AddTo(_target.TakeFrom(_amount));
    }
  }
}

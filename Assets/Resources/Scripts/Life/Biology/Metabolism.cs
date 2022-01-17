using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : MonoBehaviour
{
  [Range(0, 100)]
  public float metabolicEfficiency = 20;

  public float metabolismRate = 1;

  float metaTick = 0;

  ResourceStorageController Resources;

  CentralNervousSystem CNS;

  void Start()
  {
    Resources = GetComponentInChildren<ResourceStorageController>();
    CNS = GetComponentInParent<CentralNervousSystem>();
  }

  float CalculateFoodStorage()
  {
    float stored = 0f;
    stored += Resources.Flesh.current;
    stored += Resources.Pulp.current;
    return stored;
  }

  float Regenerate()
  {
    return CNS.Vitality.Heal(0.01f);
  }

  void Atrophy()
  {
    if (CNS.Vitality.TakeDamage(1))
    {
      Resources.Energy.AddTo(metabolicEfficiency - 1);
    }
  }

  void Metabolize()
  {
    // DIGEST FOOD
    if (CalculateFoodStorage() > 0)
    {
      (Resources.Flesh.current > Resources.Pulp.current) ? (Resources.Flesh.TakeFrom(1)) : (Resources.Pulp.TakeFrom(1));
      Resources.Energy.AddTo(2);
    }
    // CONSUME ENERGY
    if (Resources.Energy.TakeFrom(1))
    {
      if (Resources.Energy.TakeFrom(1))
      {
        (CNS.Vitality.isMaxHealth()) ? (CNS.Genetics.GainDNA(1)) : (Regenerate());
      }
    }
    else // TRADE HEALTH FOR ENERGY
    {
      Atrophy();
    }
  }

  // METABOLIC LOOP
  void Update()
  {
    metaTick += Time.deltaTime;
    if (metaTick > metabolismRate)
    {
      metaTick = 0;
      Metabolize();
    }
  }
}

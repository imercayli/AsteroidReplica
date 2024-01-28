using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelObjectBase : MonoBehaviour
{
  protected SpawnerBase _spawnerBase;
  
  public virtual void Initialize(SpawnerBase spawnerBase)
  {
     _spawnerBase = spawnerBase;
  }
}

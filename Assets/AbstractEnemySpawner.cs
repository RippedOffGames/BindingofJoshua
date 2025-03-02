using System;
using UnityEngine;


namespace EnemySpawner{
  public interface IAbstractEnemyFactory
  {
    AbstractEnemy createAbstractEnemy();
  }

  public abstract class AbstractEnemy
  {
    protected string _prefabName;
    protected GameObject _prefab;

    public AbstractEnemy()
    {
      this.getPrefabFromResource();
    }

    public void getPrefabFromResource()
    {
      _prefab = Resources.Load(String.Format("{0}", _prefabName)) as GameObject;
    }

    public GameObject getPrefab()
    {
      return _prefab;
    }
  }

  public abstract class AbstractEnemySpawner: MonoBehaviour
  {
    protected abstract class AbstractEnemyFactory : IAbstractEnemyFactory
    {
      public abstract AbstractEnemy createAbstractEnemy();
    }

    void Start()
    {
      abstractStart();
    }

    public abstract void abstractStart();
  }
}


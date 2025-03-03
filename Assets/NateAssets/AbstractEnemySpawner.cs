using System;
using UnityEngine;


namespace EnemySpawner{
  public interface IAbstractEnemyFactory
  {
    AbstractEnemy createAbstractEnemy();
  }

  public abstract class AbstractEnemy
  {
    private GameObject _prefab;

    public AbstractEnemy(string prefabName)
    {
      this.getPrefabFromResource(prefabName);
    }

    public void getPrefabFromResource(string prefabName)
    {
      _prefab = Resources.Load(String.Format("{0}", prefabName)) as GameObject;
    }

    public GameObject getPrefab()
    {
      return _prefab;
    }

    public void createAbstractEnemy()
    {
      UnityEngine.Object.Instantiate(_prefab);
    }
  }

  public abstract class AbstractEnemySpawner: MonoBehaviour
  {
    protected abstract class AbstractEnemyFactory : IAbstractEnemyFactory
    {
      public AbstractEnemy createAbstractEnemy()
      {
        AbstractEnemy enemySpawner = getEnemySpawner();
        enemySpawner.getPrefab();
        return enemySpawner;
      }

      public abstract AbstractEnemy getEnemySpawner();
    }

    void Start()
    {
      abstractStart();
    }

    public virtual void abstractStart(){}
  }
}


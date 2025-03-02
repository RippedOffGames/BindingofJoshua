using System;
using UnityEngine;


namespace EnemySpawner{
  class BlueEnemy : AbstractEnemy
  {
    public BlueEnemy() : base()
    {
      _prefabName = "BlueEnemy";
    }
  }

  public class BlueEnemySpawner : AbstractEnemySpawner
  {
    private static BlueEnemyFactory blueEnemyFactory = new BlueEnemyFactory();

    protected class BlueEnemyFactory : AbstractEnemyFactory
    {
      public override AbstractEnemy createAbstractEnemy()
      {
        return new BlueEnemy();
      }
    }

    public override void abstractStart()
    {
      var blueEnemy = BlueEnemySpawner.blueEnemyFactory.createAbstractEnemy() as BlueEnemy;
      blueEnemy.getPrefabFromResource();
      Instantiate(blueEnemy.getPrefab());
    }
  }
}

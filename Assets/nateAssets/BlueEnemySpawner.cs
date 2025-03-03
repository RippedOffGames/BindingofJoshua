using System;
using UnityEngine;


namespace EnemySpawner{
  class BlueEnemy : AbstractEnemy
  {
    public BlueEnemy(string prefabName) : base(prefabName)
    {
    }
  }

  public class BlueEnemySpawner : AbstractEnemySpawner
  {
    private static BlueEnemyFactory blueEnemyFactory = new BlueEnemyFactory();

    protected class BlueEnemyFactory : AbstractEnemyFactory
    {
      public override AbstractEnemy getEnemySpawner()
      {
        return new BlueEnemy("BlueEnemy");
      }
    }
  }
}

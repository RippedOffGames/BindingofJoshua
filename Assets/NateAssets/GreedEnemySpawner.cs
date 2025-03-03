using System;
using UnityEngine;


namespace EnemySpawner{
  class GreenEnemy : AbstractEnemy
  {
    public GreenEnemy(string prefabName) : base(prefabName)
    {
    }
  }

  public class GreenEnemySpawner : AbstractEnemySpawner
  {
    private static GreenEnemyFactory blueEnemyFactory = new GreenEnemyFactory();

    protected class GreenEnemyFactory : AbstractEnemyFactory
    {
      public override AbstractEnemy getEnemySpawner()
      {
        return new GreenEnemy("GreenEnemy");
      }
    }
  }
}


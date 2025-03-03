using UnityEngine;

namespace EnemySpawner{
  class RedEnemy : AbstractEnemy
  {
    public RedEnemy(string prefabName) : base(prefabName)
    {
    }
  }

  public class RedEnemySpawner : AbstractEnemySpawner
  {
    private static RedEnemyFactory blueEnemyFactory = new RedEnemyFactory();

    protected class RedEnemyFactory : AbstractEnemyFactory
    {
      public override AbstractEnemy getEnemySpawner()
      {
        return new RedEnemy("RedEnemy");
      }
    }
  }
}

using UnityEngine;


namespace EnemySpawner{
  sealed class RedEnemy : AbstractEnemy
  {
    public RedEnemy() : base()
    {
      _prefabName = "RedEnemy";
    }
  }

  class RedEnemySpawner : AbstractEnemySpawner
  {
    private static RedEnemyFactory redEnemyFactory = new RedEnemyFactory();

    protected class RedEnemyFactory : AbstractEnemyFactory
    {
      public override AbstractEnemy createAbstractEnemy()
      {
        return new RedEnemy();
      }
    }

    public override void abstractStart()
    {
      var redEnemy = RedEnemySpawner.redEnemyFactory.createAbstractEnemy() as RedEnemy;
      redEnemy.getPrefabFromResource();
      Instantiate(redEnemy.getPrefab());
    }
  }
}

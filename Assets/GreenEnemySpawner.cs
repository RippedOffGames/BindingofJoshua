using UnityEngine;


namespace EnemySpawner{
  sealed class GreenEnemy : AbstractEnemy
  {
    public GreenEnemy() : base()
    {
      _prefabName = "GreenEnemy";
    }
  }

  class GreenEnemySpawner : AbstractEnemySpawner
  {
    private static GreenEnemyFactory greenEnemyFactory = new GreenEnemyFactory();

    protected class GreenEnemyFactory : AbstractEnemyFactory
    {
      public override AbstractEnemy createAbstractEnemy()
      {
        return new GreenEnemy();
      }
    }

    public override void abstractStart()
    {
      var greenEnemy = GreenEnemySpawner.greenEnemyFactory.createAbstractEnemy() as GreenEnemy;
      greenEnemy.getPrefabFromResource();
      Instantiate(greenEnemy.getPrefab());
    }
  }
}

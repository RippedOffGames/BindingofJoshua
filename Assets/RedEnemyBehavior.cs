using UnityEngine;

namespace EnemySpawner{
  // The red enemy will maintain a constant distance from the player.
  sealed class RedEnemyBehavior : AbstractEnemyBehavior
  {
    public override void moveToAttack()
    {
      System.Console.WriteLine("Remember to make this enemy keep a constant distance");
    }

    public override void makeAttack()
    {
      System.Console.WriteLine("YOUR MOZER WAS A HAMSTER AND YOUR FAZER SMELLES OF ELDERBERRIES!");
    }
  }
}

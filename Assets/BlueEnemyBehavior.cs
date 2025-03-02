using UnityEngine;


namespace EnemySpawner{
  // The blue enemy will persue the player for meele attacks.
  sealed class BlueEnemyBehavior : AbstractEnemyBehavior
  {
    public override void moveToAttack()
    {
      System.Console.WriteLine("Remember to make this enemy move towards the player.");
    }

    public override void makeAttack()
    {
      System.Console.WriteLine("Hello! My name is Inego Montoya! You killed my Father! PREPARE TO DIE!!!!!!!!!!!!!!!");
    }
  }
}

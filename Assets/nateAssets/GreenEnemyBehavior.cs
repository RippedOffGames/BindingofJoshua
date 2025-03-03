using UnityEngine;


namespace EnemySpawner{
  // The green enemy will run away from the player.
  public class GreenEnemyBehavior : AbstractEnemyBehavior
  {
    public override void moveToAttack()
    {
      System.Console.WriteLine("Remember to make these guys run away.");
    }

    public override void makeAttack()
    {
      System.Console.WriteLine("AHHHHHH!!!!!!!!!!!");
    }
  }
}

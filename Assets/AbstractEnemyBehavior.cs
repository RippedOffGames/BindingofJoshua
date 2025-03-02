using UnityEngine;


namespace EnemySpawner{
  public abstract class AbstractEnemyBehavior : MonoBehaviour
  {
    private int _enemyID; // May be useful for identificaiton and logging.
    private static int _enemyCount;
    private float _distanceToPlayer;
    private int _currentHealth;
    private GameObject _prefab; // Do not mess with this, only here for destruction.

    /*
     * These fields are for modification by child classes only! |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    */
    [SerializeField] protected float _minDistanceToPlayer;  // When the player gets this close, change movement behavior.
    [SerializeField] protected int _maxHealth; // When the player gets this close, attack player.
    /*
     * These fields are for modification by child classes only! |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    */

    public virtual void Start()
    {
      _enemyCount++;
      _enemyID = _enemyCount;
      this.abstractStart();
    }

    public void takeDamage(int damageAmmt)
    {
      _currentHealth -= damageAmmt;
      if(_currentHealth < 0)
        Object.Destroy(_prefab);
    }

    private int getEnemyID()
    {
      return _enemyID;
    }

    public int getCurrentHealth()
    {
      return _currentHealth;
    }

    public void Update()
    {
      if(_distanceToPlayer < _minDistanceToPlayer){
        this.moveToAttack();
        this.makeAttack();
      }
    }

    public virtual void abstractStart(){}
    public abstract void moveToAttack();

    // For now, this should just instult the player.
    public abstract void makeAttack();
  }
}


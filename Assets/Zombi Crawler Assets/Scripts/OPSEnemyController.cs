using System.Collections;
using UnityEngine;
/*
Adrina Seda Pagan
Enemy Controller Component
An observer of the RampageMode event, wants to know when rampage
mode is enabled so it can run away
*/
public class OPSEnemyController : MonoBehaviour, IRampageObserver
{
    [SerializeField]
    private float speed = 1f;
    private bool isPaused = false;
    public bool RampageActive { get; set; } = false;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private GameObject player;
    [SerializeField]
    private float knockbackForce = 10.0f;

    // Subscribe to subject
    void OnEnable()
    {
        OPSGameManager.Instance.OnRampageModeChanged += HandleRampageModeChanged;
        // Handle the case when an enemy spawns after I activate rampage and rampage mode is active
        // Since observer is only notified during state changes
        if (OPSGameManager.Instance.IsRampageActive)
        {
            HandleRampageModeChanged(true);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (!isPaused)
        {
            Vector3 direction;
            // Handle enemy direction change on rampage mode
            if (RampageActive)
            {
                direction = (transform.position - playerTransform.position).normalized;
            }
            else
            {
                direction = (playerTransform.position - transform.position).normalized;
            }
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Knock enemy back on collision with player
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 knockbackDirection = transform.position - collision.transform.position;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            StartCoroutine(PauseMovement());
        }
    }

    // Unsubscribe from subject
    void OnDisable()
    {
        if (OPSGameManager.Instance != null)
            OPSGameManager.Instance.OnRampageModeChanged -= HandleRampageModeChanged;
    }

    private IEnumerator PauseMovement()
    {
        isPaused = true;
        yield return new WaitForSeconds(1);
        isPaused = false;
    }
    public void HandleRampageModeChanged(bool isActive)
    {
        RampageActive = isActive;
    }
}

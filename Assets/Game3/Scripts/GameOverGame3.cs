//Deja Hang
// 5/9/25

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverGame3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

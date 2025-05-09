using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadTresureCollect()
    {
        SceneManager.LoadScene("Seeker");
    }

    public void LoadObstacleDodge()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadZombieCrawler()
    {
        SceneManager.LoadScene("zombie crawler");
    }

    public void LoadFreedFromAll()
    {
        SceneManager.LoadScene("Game3Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

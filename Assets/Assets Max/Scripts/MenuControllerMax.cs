using UnityEngine;
using UnityEngine.SceneManagement;


// Max Schmit 3/13/2025
public class MenuControllerMax : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }


    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(2);
    }

}

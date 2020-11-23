using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string MainSceneName;

    public void PlayGame()
    {
        SceneManager.LoadScene(MainSceneName);
        Debug.Log("MainSceneLoaded");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}

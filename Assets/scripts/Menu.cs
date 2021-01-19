using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadSceneHomeScreen()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void LoadSceneCollection()
    {
        SceneManager.LoadScene("collection");
    }

    public void LoadSceneOpenChests()
    {
        SceneManager.LoadScene("OpenChests");
    }

    public GameObject gmFade;
    public void Battle()
    {
        gmFade.SetActive(true);
    }
    public void LoadSceneArciveItems()
    {
        SceneManager.LoadScene("archiveItems");
    }

    public static void LoadSceneRunnerGame()
    {
        SceneManager.LoadScene("runner");
    }
    public void EndGame()
    {
        LoadSceneOpenChests();
    }
    public void RestartGame()
    {
        Application.LoadLevel(0);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadSceneHomeScreen()
    {
        SceneManager.LoadScene("1_HomeScreen");
    }

    public void LoadSceneCollection()
    {
        SceneManager.LoadScene("2_archiveItems");
    }

    public void LoadSceneOpenChests()
    {
        SceneManager.LoadScene("3_OpenChests");
    }

     public static void LoadSceneRunnerGame()
    {
        SceneManager.LoadScene("5_runner");
    }
    public void LoadSceneSettings()
    {
        SceneManager.LoadScene("6_settings");
    }


    public void EndGame()
    {
        LoadSceneOpenChests();
    }
    public GameObject gmFade;
    public void Battle()
    {
        gmFade.SetActive(true);
    }
    public void RestartGame()
    {
        Application.LoadLevel(0);
    }
}

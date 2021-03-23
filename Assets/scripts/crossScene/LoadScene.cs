using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nameScene;
    void Awake()
    {
        SceneManager.LoadScene(nameScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
   // Имя загружаемой сцены
    [SerializeField] private string nextScene = "";
    // Флаг выключения анимации появления сцены
    [SerializeField] private bool disableFadeInAnimation = false;

    private void Start()
    {
        if (disableFadeInAnimation)
        {
            // При отсутствии анимации появления проигрываем FadeIn в конец при инициализации
            Animator animator = gameObject.GetComponent<Animator>();
            animator.Play("FadeIn", 0 , 1);
        }
    }


        public void LoadSceneAfterFade()
    {
        Menu.LoadSceneRunnerGame();// SceneManager.LoadScene("runner");
    }
}

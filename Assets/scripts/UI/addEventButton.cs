using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class addEventButton : MonoBehaviour
{

    public Button ButtonModif;
    private checkModificators check;
    private Menu menu;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "1_HomeScreen")
        {
            check = GameObject.Find("LevelScripts").GetComponent<checkModificators>();
            ButtonModif.onClick.AddListener(check.AddModificators);
        }

        if (SceneManager.GetActiveScene().name == "2_archiveItems")
        {
            menu = GameObject.Find("LevelScripts").GetComponent<Menu>();
            ButtonModif.onClick.AddListener(menu.OpenPreviewItem);
        }
    }



}

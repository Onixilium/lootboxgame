using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class resetLevel : MonoBehaviour
{

    public GameObject SelectChestUI, ResultChestUI;
    public  void BackToSelectChests()
    {
        ResultChestUI.SetActive(false);
        SelectChestUI.SetActive(true);
        GameObject.Find("ImageItem").SetActive(false);
    }
}

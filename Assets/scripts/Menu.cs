using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void LoadHomeScreen()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void LoadCollection()
    {
        SceneManager.LoadScene("collection");
    }

    public void LoadGatch2()
    {
        SceneManager.LoadScene("Gatch2");
    }

    public GameObject gmFade;
    public void Battle()
    {
        gmFade.SetActive(true);
    }
    public void LoadArciveItems()
    {
        SceneManager.LoadScene("archiveItems");
    }

    public static void OpenRunnerGame()
    {
        SceneManager.LoadScene("runner");
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Gatch2");
    }

    public GameObject OpenChestUI, SelectChestUI;
    public GameObject imgChest;
    public void OpenWood()
    {
        ToogleUIChest();
        imgChest.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/Chest_02_02")[0];
    }
    public void OpenSilver()
    {
        ToogleUIChest();
        imgChest.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/3typeschest")[1];
    }

    public void OpenGold()
    {
        ToogleUIChest();
        imgChest.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/3typeschest")[2];
    }

    void ToogleUIChest()
    {
        if (SelectChestUI.active)
        {
            SelectChestUI.SetActive(false);
            OpenChestUI.SetActive(true);            
        }
        else
        {
            OpenChestUI.SetActive(false);
            SelectChestUI.SetActive(true);            
        }
    }


}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public GameObject modifPanel;
    public void OpenCloseModificators()
    {
        if (modifPanel.activeSelf) modifPanel.SetActive(false);
        else modifPanel.SetActive(true);
    }

    public void ClosePreviewItem()
    {
        Transform panelTransform = GameObject.Find("PanelItem").transform;
        for (int i = 0; i <= panelTransform.transform.childCount - 1; i++)
            panelTransform.GetChild(i).gameObject.SetActive(false);
    }

    public void OpenPreviewItem()
    {
        GameObject panel = GameObject.Find("PanelItem");
        for (int i = 0; i <= panel.transform.childCount - 1; i++)
            panel.transform.GetChild(i).gameObject.SetActive(true);
        panel.transform.Find("ImageItem").GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<WeaponStats>().weapon.art;
        panel.transform.Find("TxtName").GetComponent<Text>().text = EventSystem.current.currentSelectedGameObject.GetComponent<WeaponStats>().weapon.name;
        panel.transform.Find("TxtDescription").GetComponent<Text>().text = EventSystem.current.currentSelectedGameObject.GetComponent<WeaponStats>().weapon.description;
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

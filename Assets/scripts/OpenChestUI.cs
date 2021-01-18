using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChestUI : MonoBehaviour
{
    public GameObject OpenChestUI_gm, SelectChestUI_gm, imgChest_gm, ResultChestUI_gm;
     Collection collection;

    public void Start()
    {
        collection = GameObject.Find("Collection").GetComponent<Collection>();
    }

    public void SelectBronze()
    {
        ToogleUIChest();
        imgChest_gm.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/Chest_02_02")[0];
    }
    public void SelectSilver()
    {
        ToogleUIChest();
        imgChest_gm.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/3typeschest")[1];
    }
    public void SelectGold()
    {
        ToogleUIChest();
        imgChest_gm.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/3typeschest")[2];
    }

    void ToogleUIChest()
    {
        if (SelectChestUI_gm.active)
        {
            SelectChestUI_gm.SetActive(false);
            OpenChestUI_gm.SetActive(true);
        }
        else
        {
            OpenChestUI_gm.SetActive(false);
            SelectChestUI_gm.SetActive(true);
        }
    }

    public void OpenChest()
    {
        if (collection.tickets > 0)
        {
            //getRndWeapon.GetComponent<GetRndWeapon>().glowbgAnimation();
            OpenChestUI_gm.SetActive(false);
            ResultChestUI_gm.SetActive(true);
        }
    }

    public void DefaultViews()
    {
        ResultChestUI_gm.SetActive(false);
        SelectChestUI_gm.SetActive(true);
        GameObject.Find("ImageItem").SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChestUI : MonoBehaviour
{
    public GameObject OpenChestUI_gm, SelectChestUI_gm, imgChest_gm, ResultChestUI_gm, TopUi,BotUI;
    Collection collection;
    public bool BronzeChest = false, SilverChest = false, GoldChest = false;

    public void Start()
    {
        collection = GameObject.Find("GlobalObject").GetComponent<Collection>();
        SetUiText.SetAllKeyText();
    }

    public void SelectBronze()
    {
        if (collection.quantityBronzeKey > 0)
        {
            imgChest_gm.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/Chest_02_02")[0];
            BronzeChest = true;
            collection.quantityBronzeKey--;
            SetUiText.SetAllKeyText();
            ToogleUIChest();
        }
    }
    public void SelectSilver()
    {
        if (collection.quantitySilverKey > 0)
        {
            imgChest_gm.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/3typeschest")[1];
            SilverChest = true;
            collection.quantitySilverKey--;
            SetUiText.SetAllKeyText();
            ToogleUIChest();
        }
    }
    public void SelectGold()
    {
        if (collection.quantityGoldKey > 0)
        {
            imgChest_gm.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("pic/3typeschest")[2];
            GoldChest = true;
            collection.quantityGoldKey--;
            SetUiText.SetAllKeyText();
            ToogleUIChest();
        }
    }

    void ToogleUIChest()
    {
        if (SelectChestUI_gm.active)
        {
            SelectChestUI_gm.SetActive(false);
            OpenChestUI_gm.SetActive(true);
            TopUi.SetActive(false);
            BotUI.SetActive(false);
        }
        else
        {
            OpenChestUI_gm.SetActive(false);
            SelectChestUI_gm.SetActive(true);
        }
    }

    /// <summary>
    /// Calls from editor
    /// </summary>
    public void OpenChest()
    {
        OpenChestUI_gm.SetActive(false);
        ResultChestUI_gm.SetActive(true);
    }

    public void DefaultViews()
    {
        ResultChestUI_gm.SetActive(false);
        SelectChestUI_gm.SetActive(true);
        TopUi.SetActive(true);
        BotUI.SetActive(true);
        GameObject.Find("ImageItem").SetActive(false);
    }

}

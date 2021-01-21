using UnityEngine;
using UnityEngine.UI;
using  System;
using System.Collections;
using System.Collections.Generic;


public class GetRndWeapon : MonoBehaviour
{
    weapon w;

    public WeaponDisplay weaponDisplay;
    public GameObject card;
    public Collection collection;

    public GameObject OpenChestUI, ResultChestUI;

    SetUiText setUiText;

    OpenChestUI SceneManager;


    public void Start()
    {
        collection = GameObject.Find("Collection").GetComponent<Collection>();
        setUiText = GameObject.Find("SceneManager").GetComponent<SetUiText>();

        SceneManager = GameObject.Find("SceneManager").GetComponent<OpenChestUI>();
    }



    public void glowbgAnimation()
    {
        OpenChestUI.SetActive(false);
        ResultChestUI.SetActive(true);
    }

    public void SetVisibleCard()
    {    
        card.SetActive(true);
        SetResourcesImage();
        AddToMemory();
    }
    int itemIndex;
    private void SetResourcesImage()
    {
        UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
        var dice = UnityEngine.Random.Range(0, 100);

        if (SceneManager.BronzeChest)  { w = BronzeChest()[UnityEngine.Random.Range(0, BronzeChest().Count - 1)]; SceneManager.BronzeChest = false; }
        if (SceneManager.SilverChest) { w = SilverChest()[UnityEngine.Random.Range(0, SilverChest().Count - 1)]; SceneManager.SilverChest = false; }
        if (SceneManager.GoldChest) { w = GoldChest()[UnityEngine.Random.Range(0, GoldChest().Count - 1)]; SceneManager.GoldChest = false; }

        weaponDisplay.weapon = w;
        weaponDisplay.nameText.text = w.name;
        weaponDisplay.attackText.text = w.attack.ToString();
        weaponDisplay.art.sprite = w.art;


        collection.listweap.Add(w);

        w.Opened = true;
    }

 
    public  void AddToMemory()
    {
        collection.tickets--;        
        setUiText.SetBronzeKeyText(collection.tickets);
        collection.SavePlayer();
    }

    public List<weapon> listBronze;
    public List<weapon> listSilver;
    public List<weapon> listGold;

    private List<weapon> BronzeChest()
    {
        for (int i = 0; i <=64; i++)
        {
              if (collection.weapon[i].description == "common")
                  listBronze.Add(collection.weapon[i]);
        }
       return listBronze;
    }

    private List<weapon> SilverChest()
    {
        for (int i = 0; i <= 64; i++)
        {
            if (collection.weapon[i].description == "rare")
                listSilver.Add(collection.weapon[i]);
        }
      return listSilver;
    }

    private List<weapon> GoldChest()
    {
        for (int i = 0; i <= 64; i++)
        {
            if (collection.weapon[i].description == "epic")
                listGold.Add(collection.weapon[i]);
        }
      return listGold;
    }
}

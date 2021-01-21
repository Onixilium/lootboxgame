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


    public void Start()
    {
        collection = GameObject.Find("Collection").GetComponent<Collection>();
        setUiText = GameObject.Find("SceneManager").GetComponent<SetUiText>();
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
       // dice = 95;
        Debug.Log(dice);
        if (dice >= 0 && dice<=50)  { w = BronzeChest()[UnityEngine.Random.Range(0, BronzeChest().Count - 1)];  }
        if (dice >= 51 && dice<=90) { w = SilverChest()[UnityEngine.Random.Range(0, SilverChest().Count - 1)]; }
        if (dice >= 91 && dice<=100 ) { w = GoldChest()[UnityEngine.Random.Range(0, GoldChest().Count - 1)]; }

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

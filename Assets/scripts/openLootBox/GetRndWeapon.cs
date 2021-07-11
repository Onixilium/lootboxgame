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

    const int chestCount = 64;

    public void Start()
    {
        collection = GameObject.Find("GlobalObject").GetComponent<Collection>();
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

    private void SetResourcesImage()
    {
        UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
        var dice = UnityEngine.Random.Range(0, 100);
        int percent = Mathf.RoundToInt((dice / chestCount) * 100);

        if (SceneManager.BronzeChest)  { w = BronzeChest(percent); SceneManager.BronzeChest = false; }
        if (SceneManager.SilverChest) { w = SilverChest(percent); SceneManager.SilverChest = false; }
        if (SceneManager.GoldChest) { w = GoldChest(percent); SceneManager.GoldChest = false; }

        weaponDisplay.weapon = w;
        weaponDisplay.nameText.text = w.name;
        weaponDisplay.attackText.text = w.attack.ToString();
        weaponDisplay.art.sprite = w.art;
       
        if (w.rarity == weapon.rarityEnum.common) weaponDisplay.rarityText.color = new Color(255, 255, 255);
        if (w.rarity == weapon.rarityEnum.rare) weaponDisplay.rarityText.color = new Color(255, 135, 0);
        if (w.rarity == weapon.rarityEnum.epic) weaponDisplay.rarityText.color = new Color(239, 0, 169);
        weaponDisplay.rarityText.text = w.rarity.ToString();

        w.Opened = true;
    }

 
    public  void AddToMemory()
    {
        collection.tickets--;        
        setUiText.SetBronzeKeyText(collection.tickets);
        collection.SavePlayer();
    }

    private weapon BronzeChest(int percent)
    {
        if (percent >= 1 && percent <= 80)    return GetWeapon(Chests.wood, weapon.rarityEnum.common);
        if (percent >= 81 && percent <= 99)   return GetWeapon(Chests.wood, weapon.rarityEnum.rare);
        if (percent == 100)                return GetWeapon(Chests.wood, weapon.rarityEnum.epic);
        return null;
    }

    private weapon SilverChest(int percent)
    {
        if (percent >= 1 && percent <= 48)   return GetWeapon(Chests.silver, weapon.rarityEnum.common);
        if (percent >= 49 && percent <= 98)  return GetWeapon(Chests.silver, weapon.rarityEnum.rare);
        if (percent >= 99 && percent <= 100) return GetWeapon(Chests.silver, weapon.rarityEnum.epic);
        return null;
    }

    private weapon GoldChest(int percent)
    {
        if (percent >= 1 && percent <= 15)      return GetWeapon(Chests.gold, weapon.rarityEnum.common);
        if (percent >= 16 && percent <= 75)     return GetWeapon(Chests.gold, weapon.rarityEnum.rare);
        if (percent >= 76 && percent <= 100)    return GetWeapon(Chests.gold, weapon.rarityEnum.epic);
        return null;
    }


    public List<weapon> listWeapons;

    private weapon GetWeapon(Chests chest, weapon.rarityEnum rarity)
    {

        for (int i = 0; i <= chestCount; i++)
        {
            if (collection.weapon[i].rarity == rarity)
                listWeapons.Add(collection.weapon[i]);
        }

        var rewardWeapon = listWeapons[UnityEngine.Random.Range(0, listWeapons.Count - 1)];
        return rewardWeapon;
    }


    private enum Chests
    {
        wood,
        silver,
        gold
    }

}

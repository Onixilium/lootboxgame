using UnityEngine;
using UnityEngine.UI;
using  System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        int percent = Mathf.RoundToInt(((float)dice/chestCount) * 100);

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
        SetUiText.SetKeyText(collection.quantityBronzeKey,  Chests.bronze);
        collection.SavePlayer();
    }

    private weapon BronzeChest(int percent)
    {
        if (Enumerable.Range(1, 80).Contains(percent))  return GetWeapon( weapon.rarityEnum.common);
        if (Enumerable.Range(81, 99).Contains(percent)) return GetWeapon(weapon.rarityEnum.rare);
        if (percent == 100)                             return GetWeapon( weapon.rarityEnum.epic);
        return null;
    }

    private weapon SilverChest(int percent)
    {
        if (Enumerable.Range(1, 48).Contains(percent))      return GetWeapon( weapon.rarityEnum.common);
        if (Enumerable.Range(49, 98).Contains(percent))     return GetWeapon( weapon.rarityEnum.rare);
        if (Enumerable.Range(99, 100).Contains(percent))    return GetWeapon(weapon.rarityEnum.epic);
        return null;
    }

    private weapon GoldChest(int percent)
    {
        if (Enumerable.Range(1, 15).Contains(percent))      return GetWeapon( weapon.rarityEnum.common);
        if (Enumerable.Range(16, 85).Contains(percent))     return GetWeapon(weapon.rarityEnum.rare);
        if (Enumerable.Range(86, 100).Contains(percent))    return GetWeapon( weapon.rarityEnum.epic);
        return null;
    }




    private weapon GetWeapon(weapon.rarityEnum rarity)
    {   
        List<weapon> listWeapons = new List<weapon>();
        for (int i = 0; i <= chestCount; i++)
        {
            if (collection.weapon[i].rarity == rarity)
                listWeapons.Add(collection.weapon[i]);
        }

        var rewardWeapon = listWeapons[UnityEngine.Random.Range(0, listWeapons.Count - 1)];
        return rewardWeapon;
    }


    public enum Chests
    {
        bronze,
        silver,
        gold
    }

}

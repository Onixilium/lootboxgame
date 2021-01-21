using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public weapon weapon;
    public Image art;

    public Text nameText;
    public Text attackText;
    public Text rarityText;
    public Text description;    

    void Start()
    {
        nameText.text = weapon.name;
        attackText.text = weapon.attack.ToString();
        art.sprite = weapon.art;
      /* rarityText.text = weapon.rarity;
        if (weapon.rarity == "common") rarityText.color = new Color(255, 255, 255);
        if (weapon.rarity == "rare") rarityText.color = new Color(255, 135, 0);
        if (weapon.rarity == "epic") rarityText.color = new Color(239, 0, 169);*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public weapon weapon;

    public Text nameText;
    public Text attackText;
    public Text rarity;
    public Text description;

    public Image art;


    void Start()
    {
        nameText.text = weapon.name;
        attackText.text = weapon.attack.ToString();
        art.sprite = weapon.art;
        if (weapon.description == "common") rarity.color = new Color(255, 255, 255);
        if (weapon.description == "rare")   rarity.color = new Color(255, 135, 0);
        if (weapon.description == "epic")   rarity.color = new Color(239, 0, 169);

        rarity.text = weapon.description;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageOpenScene : MonoBehaviour
{
    public Text WoodQ, SilverQ, GoldQ;
    Collection collection;
    public GameObject getRndWeapon;
    // Start is called before the first frame update
    void Start()
    {    
        LoadQuantity();
    }

    public void OpenChest()
    {
        if (collection.tickets > 0)
        {
        getRndWeapon.GetComponent<GetRndWeapon>().glowbgAnimation();
           
        }
    }
    
    public void LoadQuantity()
    {
        collection = GameObject.Find("Collection").GetComponent<Collection>();
        WoodQ.text = collection.quantityWoodChest.ToString();
        SilverQ.text = collection.quantitySilverChest.ToString();
        GoldQ.text = collection.quantityGoldChest.ToString();
    }
}

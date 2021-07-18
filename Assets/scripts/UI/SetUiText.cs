using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUiText : MonoBehaviour
{


 
    public void Start() //вынести также в функцию, ибо.. какого 
    {
        
    }

    public static void SetKeyText(int quantity, GetRndWeapon.Chests chests)
    {
        Text bronzeKeyText, silverKeyText, goldKeyText;
        // if(GameObject.Find("bronzeKeyText") != null)
        if (chests == GetRndWeapon.Chests.bronze && GameObject.Find("bronzeKeyText") != null)
        {
            bronzeKeyText = GameObject.Find("bronzeKeyText").GetComponent<Text>();
            bronzeKeyText.text = quantity.ToString();
        }

       // if (GameObject.Find("silverKeyText") != null)
            if (chests == GetRndWeapon.Chests.silver && GameObject.Find("silverKeyText") != null)
        {
            silverKeyText = GameObject.Find("silverKeyText").GetComponent<Text>();
            silverKeyText.text = quantity.ToString();
        }

        //if (GameObject.Find("goldKeyText") != null)
            if (chests == GetRndWeapon.Chests.gold && GameObject.Find("goldKeyText") != null)
        {
            goldKeyText = GameObject.Find("goldKeyText").GetComponent<Text>();
            goldKeyText.text = quantity.ToString();
        }
    }

    public static void SetAllKeyText()
    {
        if (GameObject.Find("bronzeKeyText") != null && GameObject.Find("silverKeyText") != null && GameObject.Find("goldKeyText") != null)
        {
            var collection = GameObject.Find("GlobalObject").GetComponent<Collection>();

            GameObject.Find("bronzeKeyText").GetComponent<Text>().text = collection.quantityBronzeKey.ToString();
            GameObject.Find("silverKeyText").GetComponent<Text>().text = collection.quantitySilverKey.ToString();
            GameObject.Find("goldKeyText").GetComponent<Text>().text = collection.quantityGoldKey.ToString();
        }

    }

    public static void SetScoresRunner(float score)
    {
        Text scoresText;
        scoresText = GameObject.Find("ScoresRunner").GetComponent<Text>();
        scoresText.text = score.ToString();
    }

    public static void SetModifValues(float speed, float points)
    {
        GameObject.Find("AddSpeedTxt").GetComponent<Text>().text = speed.ToString();
        GameObject.Find("AddPointsTxt").GetComponent<Text>().text = points.ToString();
    }
    


}

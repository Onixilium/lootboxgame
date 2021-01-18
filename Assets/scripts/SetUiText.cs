using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUiText : MonoBehaviour
{
    Collection collection;
    Text bronzeKeyText,silverKeyText, goldKeyText;

    public void Start()
    {
        collection = GameObject.Find("Collection").GetComponent<Collection>();
        SetBronzeKeyText(collection.tickets);
    }

    public void SetBronzeKeyText(int quantity)
    {
        bronzeKeyText = GameObject.Find("bronzeKeyText").GetComponent<Text>();
        bronzeKeyText.text = quantity.ToString();
    }



}

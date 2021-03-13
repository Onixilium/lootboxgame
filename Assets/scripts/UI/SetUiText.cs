using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUiText : MonoBehaviour
{
    Collection collection;
    Text bronzeKeyText, silverKeyText, goldKeyText, scoresText;

    public void Start() //вынести также в функцию, ибо.. какого 
    {
      /*  if (GameObject.Find("Collection"))
        {
            collection = GameObject.Find("Collection").GetComponent<Collection>();
            SetBronzeKeyText(collection.tickets);
        }*/
    }

    public void SetBronzeKeyText(int quantity)
    {
        bronzeKeyText = GameObject.Find("bronzeKeyText").GetComponent<Text>();
        bronzeKeyText.text = quantity.ToString();
    }

    public void SetScoresRunner(float score)
    {
        scoresText = GameObject.Find("ScoresRunner").GetComponent<Text>();
        scoresText.text = score.ToString();
    }

    


}

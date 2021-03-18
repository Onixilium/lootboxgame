using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadArchive : MonoBehaviour
{
   public Button buttonPrefab;
   Collection collection;
   GameObject inventory;

    void Start()
    {
        collection  = GameObject.Find("Collection").GetComponent<Collection>();
        inventory = GameObject.Find("Content");
        FillVisualArchive();
    }      

     
    private void FillVisualArchive()
    { 
        for (int i = 0; i <=65-1; i++)
        {
            if (collection.weapon[i].Opened == true)
            { buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.white; }
            else
            { buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.black;  }             

            buttonPrefab.transform.Find("ART").GetComponent<Image>().sprite = collection.weapon[i].art;
            Button newButton = (Button)Instantiate(buttonPrefab);
            newButton.transform.SetParent(inventory.transform, false);                   
        }
    }
        
}

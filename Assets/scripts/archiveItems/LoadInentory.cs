using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInentory : MonoBehaviour
{
    public Button buttonPrefab;
    
   void Start()
    {
       /* Collection collection = GameObject.Find("Collection").GetComponent<Collection>();
       int quantutyItems = collection.listweap.Count;
        if (quantutyItems > 0)
        {
            for(int i=0;i<quantutyItems; i++)
            {
                GameObject inventory = GameObject.Find("Content");
                buttonPrefab.GetComponentInChildren<Text>().text = collection.listweap[i].name;
                buttonPrefab.GetComponentInChildren<Image>().sprite = collection.listweap[i].art;
                Button newButton = (Button)Instantiate(buttonPrefab);
                newButton.transform.SetParent(inventory.transform, false);
            } 
        }    */    
    }
}
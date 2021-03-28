using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadArchive : MonoBehaviour
{
   public Button buttonPrefab;
   Collection collection;

    void Start()
    {
        collection  = GameObject.Find("GlobalObject").GetComponent<Collection>();

        if (SceneManager.GetActiveScene().name == "1_HomeScreen") { GameObject Grid = GameObject.Find("Content_epic"); FillRarestModif(Grid);  }
        if (SceneManager.GetActiveScene().name == "1_HomeScreen") { GameObject Grid = GameObject.Find("Content_modif"); FillVisualArchive(Grid);  }
        if (SceneManager.GetActiveScene().name == "2_archiveItems") { GameObject Grid = GameObject.Find("Content"); FillVisualArchive(Grid);  }
    }      

     
    private void FillVisualArchive(GameObject Grid)
    { 
      for (int i = 0; i <=65-1; i++)
        {
            if (collection.weapon[i].Opened == true)
            { buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.white; }
            else
            { buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.black;  }             

            buttonPrefab.transform.Find("ART").GetComponent<Image>().sprite = collection.weapon[i].art;
            Button newButton = (Button)Instantiate(buttonPrefab);
            newButton.transform.SetParent(Grid.transform, false);                   
        }
    }

    private void FillRarestModif(GameObject Grid)
    {
        for (int i = 0; i <= 65 - 1; i++)
        {
            if (collection.weapon[i].rarity == "epic")
            {
                if (collection.weapon[i].Opened == true)
                { buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.white; }
                else
                { buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.black; }

                buttonPrefab.transform.Find("ART").GetComponent<Image>().sprite = collection.weapon[i].art;
                Button newButton = (Button)Instantiate(buttonPrefab);
                newButton.transform.SetParent(Grid.transform, false);
            }
        }
    }
        
}

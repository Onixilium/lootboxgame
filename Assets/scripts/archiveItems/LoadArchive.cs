using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadArchive : MonoBehaviour
{
   public Button buttonPrefab;
   public Button buttonModif;
   public Button buttonEpic;
   Collection collection;

    void Start()
    {
        collection  = GameObject.Find("GlobalObject").GetComponent<Collection>();

        if (SceneManager.GetActiveScene().name == "1_HomeScreen") { GameObject Grid = GameObject.Find("Content_epic"); FillRarest(Grid);  }
        if (SceneManager.GetActiveScene().name == "1_HomeScreen") { GameObject Grid = GameObject.Find("Content_modif"); FillModif(Grid);  }
        if (SceneManager.GetActiveScene().name == "2_archiveItems") { GameObject Grid = GameObject.Find("Content"); FillVisualArchive(Grid);  }
    }      

     /// <summary>
     /// Сетка предметов в Сундуке
     /// </summary>
     /// <param name="Grid"></param>
    private void FillVisualArchive(GameObject Grid)
    { 
      for (int i = 0; i <=65-1; i++)
        {
            if (collection.weapon[i].Opened == true)
            { buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.white; }
            else
            {
                buttonPrefab.transform.Find("ART").GetComponent<Image>().color = Color.black;
                buttonPrefab.GetComponent<Button>().enabled = false;
            }

            buttonPrefab.transform.Find("ART").GetComponent<Image>().sprite = collection.weapon[i].art;
            Button newButton = (Button)Instantiate(buttonPrefab);
            newButton.gameObject.GetComponent<WeaponStats>().SetParams(collection.weapon[i]);//
            newButton.transform.SetParent(Grid.transform, false);                   
        }
    }

    /// <summary>
    /// Сетка предметов Главная страница-Модификаторы
    /// </summary>
    /// <param name="Grid"></param>
    private void FillModif(GameObject Grid)
    {
        for (int i = 0; i <= 65 - 1; i++)
        {
            if (collection.weapon[i].Opened == true)
            {
                buttonModif.transform.Find("ART").GetComponent<Image>().color = Color.white;
                buttonModif.transform.Find("ART").GetComponent<Image>().sprite = collection.weapon[i].art;
                Button newButton = Instantiate(buttonModif);
                newButton.gameObject.GetComponent<WeaponStats>().SetParams(collection.weapon[i]);
                newButton.transform.SetParent(Grid.transform, false);
            }         
        }
    }


    /// <summary>
    /// Сетка предметов Главная страница-Редчашие предметы
    /// </summary>
    /// <param name="Grid"></param>
    private void FillRarest(GameObject Grid)
    {
        for (int i = 0; i <= 65 - 1; i++)
        {
            if (collection.weapon[i].rarity == "epic")
            {
                if (collection.weapon[i].Opened == true)
                { buttonEpic.transform.Find("ART").GetComponent<Image>().color = Color.white; }
                else
                { buttonEpic.transform.Find("ART").GetComponent<Image>().color = Color.black; }

                buttonEpic.transform.Find("ART").GetComponent<Image>().sprite = collection.weapon[i].art;
                Button newButton = (Button)Instantiate(buttonEpic);
                newButton.transform.SetParent(Grid.transform, false);
            }
        }
    }
        
}

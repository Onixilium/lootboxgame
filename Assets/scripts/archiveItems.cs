using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class archiveItems : MonoBehaviour
{
    public List<Archive> archive;
    public Archive ar1;

    public Button buttonPrefab;

    void Start()
    {
       
       
    }

    void Awake()
    {
        FillArchive();
        FillVisualArchive();
    }

    private void FillArchive()
    {
        archive = new List<Archive>();
        weapon[] listweapon = Resources.LoadAll<weapon>("");
        for (int i = 0; i <= listweapon.Length-1; i++)
        {
            ar1 = new Archive();
            ar1.weapon = listweapon[i];
            ar1.opened = false;
         //   if (i % 2 == 0) ar1.opened = true;
            archive.Add(ar1);
        }
    }

    public void ChangeStateItem(int i)
    {
        archive[i].opened = true;
    }


    private void FillVisualArchive()
    {
        if (SceneManager.GetActiveScene().name == "archiveItems")      {
            archiveItems archiveItems = GameObject.Find("Archive").GetComponent<archiveItems>();

            if (archiveItems is null) return;

            int quantutyItems = archiveItems.archive.Count;

            if (quantutyItems > 0)
            {
                for (int i = 0; i < quantutyItems-1; i++)
                {
                    GameObject inventory = GameObject.Find("Content");

                    if (archiveItems.archive[i].opened == false) buttonPrefab.GetComponentInChildren<Image>().color = Color.black;
                    else buttonPrefab.GetComponentInChildren<Image>().color = Color.white;

                    buttonPrefab.GetComponentInChildren<Image>().sprite = archiveItems.archive[i].weapon.art;
                    Button newButton = (Button)Instantiate(buttonPrefab);
                    newButton.transform.SetParent(inventory.transform, false);
                }
            }
        }
    }
}

   

public class Archive {
    public weapon weapon;
    public bool opened;
}

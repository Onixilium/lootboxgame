using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Collection : MonoBehaviour
{
    public List<weapon> listweap;
    public int tickets;
    public int quantityWoodChest, quantitySilverChest, quantityGoldChest;

    public PlayerStatistics localPlayerData = new PlayerStatistics();

    public static Collection Instance;
    public Collection LocalCopyOfData;
       

    public Text ticketsText;

    public weapon[] weapon;
    void Start()
    {
        localPlayerData = GlobalControl.Instance.savedPlayerData;

        weapon = Resources.LoadAll<weapon>("");
        ticketsText = GameObject.Find("TextTickets1").GetComponent<Text>();
        ticketsText.text = tickets.ToString();
    }


    private void OnLevelWasLoaded(int level)
    {
     if(GameObject.Find("TextTickets1") == null) { 
        ticketsText = GameObject.Find("TextTickets1").GetComponent<Text>();
        ticketsText.text = tickets.ToString(); 
        }
    }

    static bool created = false;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
          Destroy(this.gameObject);
        }
    }
    public string JsonString = "";
    public void SavePlayer()
    {
        JsonString = SaveToString();

        localPlayerData.JsonString = JsonString; 
        GlobalControl.Instance.SaveData(); 
    }

    public void LoadData()
    {        
        GlobalControl.Instance.LoadData();
        LoadFromString(GlobalControl.Instance.LocalCopyOfData.JsonString);

        ticketsText.text = tickets.ToString();
    }

    //удобно
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromString(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
    }

}

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
    public List<Archive> archive;

    public int tickets;
    public int quantityWoodChest, quantitySilverChest, quantityGoldChest;
    public PlayerStatistics localPlayerData = new PlayerStatistics();
    public static Collection Instance;
    public Collection LocalCopyOfData;
    SetUiText setUiText;
    public Text ticketsText;
    public weapon[] weapon;
    

    void Start()
    {
        localPlayerData = GlobalControl.Instance.savedPlayerData;

        weapon = Resources.LoadAll<weapon>("");

        setUiText = GameObject.Find("SceneManager").GetComponent<SetUiText>();
        setUiText.SetBronzeKeyText(tickets);
    }


    private void OnLevelWasLoaded()
    {
        setUiText.SetBronzeKeyText(tickets);
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

        setUiText.SetBronzeKeyText(tickets);

        GameObject.Find("Archive").GetComponent<archiveItems>().archive = this.archive;
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

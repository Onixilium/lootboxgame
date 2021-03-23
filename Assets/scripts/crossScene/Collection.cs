using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class Collection : MonoBehaviour
{
   // public List<weapon> listweap;


    public int tickets;
    public int quantityWoodChest, quantitySilverChest, quantityGoldChest;
    public PlayerStatistics localPlayerData = new PlayerStatistics();
    public static Collection Instance;
    public Collection LocalCopyOfData;
    
    public Text ticketsText;
    public weapon[] weapon;

    SetUiText setUiText;
    void Start()
    {
        localPlayerData = GlobalControl.Instance.savedPlayerData;

        weapon = Resources.LoadAll<weapon>("");

        setUiText = GameObject.Find("GlobalObject").GetComponent<SetUiText>();
        setUiText.SetBronzeKeyText(tickets);
    }

    void Update()
    {
  
    }

    private void OnLevelWasLoaded(int level)
    {
        if (GameObject.Find("MENU")  != null)
        {
            setUiText = GameObject.Find("MENU").GetComponent<SetUiText>();
            setUiText.SetBronzeKeyText(tickets);//and later will be add other keys
        }
        if(GameObject.Find("clear") != null)
        {
            GameObject.Find("clear").GetComponent<Button>().onClick.AddListener(GlobalControl.Instance.ClearData); //GlobalControl.Instance.ClearData(
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
        localPlayerData.JsonString = ""; //else json string will be adding
        localPlayerData.JsonString = SaveToString(); 
        GlobalControl.Instance.SaveData(); 
    }

    public void LoadData()
    {        
        GlobalControl.Instance.LoadData();
        LoadFromString(GlobalControl.Instance.LocalCopyOfData.JsonString);

        //setUiText.SetBronzeKeyText(tickets);
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

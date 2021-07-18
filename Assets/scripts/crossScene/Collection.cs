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
    public int quantityBronzeKey, quantitySilverKey, quantityGoldKey;
    public PlayerStatistics localPlayerData = new PlayerStatistics();
    public static Collection Instance;
    public Collection LocalCopyOfData;
    
    public Text quantityBronzeKeyText, quantitySilverKeyText, quantityGoldKeyText;
    public weapon[] weapon;

    SetUiText setUiText;
    void Start()
    {
        localPlayerData = GlobalControl.Instance.savedPlayerData;

        weapon = Resources.LoadAll<weapon>("");

        SetUpAllTextKeys();
    }

    void Update()
    {
  
    }

    private void SetUpAllTextKeys()
    {
       // setUiText = GameObject.Find("GlobalObject").GetComponent<SetUiText>();
        SetUiText.SetKeyText(quantityBronzeKey, GetRndWeapon.Chests.bronze);
        SetUiText.SetKeyText(quantitySilverKey, GetRndWeapon.Chests.silver);
        SetUiText.SetKeyText(quantityGoldKey, GetRndWeapon.Chests.gold);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (GameObject.Find("MENU")  != null)
        {
            SetUpAllTextKeys();
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

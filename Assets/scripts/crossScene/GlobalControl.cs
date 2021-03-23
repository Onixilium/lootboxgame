using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
using UnityEditor; 
#endif

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public PlayerStatistics savedPlayerData = new PlayerStatistics();
    public PlayerStatistics LocalCopyOfData;
    private string filePath;

     void Start()
    {
             filePath = Application.persistentDataPath + "/save.txt";
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool IsSceneBeingLoaded = false;

    public void SaveData()
   {
        BinaryFormatter formatter = new BinaryFormatter();
       
        FileStream saveFile = File.Create(filePath);

        LocalCopyOfData = GameObject.Find("GlobalObject").GetComponent<Collection>().localPlayerData;
        formatter.Serialize(saveFile, LocalCopyOfData);
        saveFile.Close();
    }

    public void LoadData()
    {
        if (System.IO.File.Exists(filePath))
        {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Open(filePath, FileMode.Open);

        LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(saveFile);

        saveFile.Close();
        }
    }

    public void ClearData()
    {        
       File.Delete(filePath); Application.Quit();
        var col = GameObject.Find("GlobalObject").GetComponent<Collection>();
        for(int i = 0; i <= 64; i++)
        {
            col.weapon[i].Opened = false;
            //EditorUtility.SetDirty(col.weapon[i]);
           // EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }
        //GameObject.Find("MENU").GetComponent<Menu>().RestartGame();
    }
}

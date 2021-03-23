using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSaveLoad : MonoBehaviour
{
    Collection collection;

    void Start()
    {
        collection = GameObject.Find("GlobalObject").GetComponent<Collection>();
        collection.LoadData();
    }

    
}

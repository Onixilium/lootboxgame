using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{

    public void ChangeLanguage(string language)
    {
        GameObject.Find("GlobalObject").GetComponent<currentGameLanguage>().language = language;
    }
}

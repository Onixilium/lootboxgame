using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentGameLanguage : MonoBehaviour
{
    public string language;
    // Start is called before the first frame update
    void Start()
    {
        I18n.lang = language.ToLower();
        I18n.LoadLanguage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 class I18n 
{
    /// <summary>
    /// Text Fields
    /// Useage: Fields[key]
    /// Example: I18n.Fields["world"]
    /// </summary>
    public static Dictionary<String, String> Fields { get; private set; }

    /// <summary>
    /// Init on first use
    /// </summary>
    static I18n()
    {
       // LoadLanguage();
    }
   public static string lang;
    /// <summary>
    /// Load language files from ressources
    /// </summary>
    public static void LoadLanguage()
    {
        if (Fields == null)
            Fields = new Dictionary<string, string>();

        Fields.Clear();
       // lang = Get2LetterISOCodeFromSystemLanguage().ToLower();
       // lang = "RU";
        var textAsset = Resources.Load(@"I18n/" + lang); //no .txt needed
        string allTexts = "";
        if (textAsset == null)
            textAsset = Resources.Load(@"I18n/en") as TextAsset; //no .txt needed
        if (textAsset == null)
            Debug.LogError("File not found for I18n: Assets/Resources/I18n/" + lang + ".txt");
        allTexts = (textAsset as TextAsset).text;
        string[] lines = allTexts.Split(new string[] { "\r\n", "\n" },
            StringSplitOptions.None);
        string key, value;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IndexOf("=") >= 0 && !lines[i].StartsWith("#"))
            {
                key = lines[i].Substring(0, lines[i].IndexOf("="));
                value = lines[i].Substring(lines[i].IndexOf("=") + 1,
                        lines[i].Length - lines[i].IndexOf("=") - 1).Replace("\\n", Environment.NewLine);
                Fields.Add(key, value);
            }
        }
    }

    /// <summary>
    /// get the current language
    /// </summary>
    /// <returns></returns>
    public static string GetLanguage()
    {
        return Get2LetterISOCodeFromSystemLanguage().ToLower();
    }

    /// <summary>
    /// Helps to convert Unity's Application.systemLanguage to a 
    /// 2 letter ISO country code. There is unfortunately not more
    /// countries available as Unity's enum does not enclose all
    /// countries.
    /// </summary>
    /// <returns>The 2-letter ISO code from system language.</returns>
    public static string Get2LetterISOCodeFromSystemLanguage()
    {
        SystemLanguage lang = Application.systemLanguage;
        string res = "EN";
        switch (lang)
        {           
            case SystemLanguage.English: res = "EN"; break;           
            case SystemLanguage.Russian: res = "RU"; break;            
        }
        //		Debug.Log ("Lang: " + res);
        return res;
    }

  

}

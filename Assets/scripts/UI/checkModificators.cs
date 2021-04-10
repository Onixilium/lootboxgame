using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class checkModificators : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void AddModificators()
    {
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;//gameobject from pressed button
        var scriptModificotrs  = GameObject.Find("GlobalObject").GetComponent<modificators>();

        if (gameObject.transform.Find("Text").GetComponent<Text>().text != "")
        {
            
        }
        else
        {
            weapon w = gameObject.GetComponent<WeaponStats>().weapon;
            scriptModificotrs.modificatores.Add(w);
            scriptModificotrs.AddMultuply();
            gameObject.transform.Find("Image").GetComponent<Image>().color = new Color(255, 127, 0, 255);
            gameObject.transform.Find("Text").GetComponent<Text>().text = scriptModificotrs.modificatores.Count.ToString();
        }
    }

    public void ResetModificators()//добавить сброс цифр и картинок у предметов
    {
        var scriptModificotrs = GameObject.Find("GlobalObject").GetComponent<modificators>();
        scriptModificotrs.modificatores.RemoveRange(0, scriptModificotrs.modificatores.Count);
    }
}

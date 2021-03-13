using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

   
    public void AddModificators(GameObject gameObject)
    {
        var scriptModificotrs  = GameObject.Find("Collection").GetComponent<modificators>();

        weapon w = new weapon();
        scriptModificotrs.modificatores.Add(w);

        //text.text = scriptModificotrs.modificatores.Count.ToString();
        // gameObject.transform.FindChild("Image")
        gameObject.transform.Find("Image").GetComponent<Image>().color = new Color(255, 255, 255, 255);
        gameObject.transform.Find("Text").GetComponent<Text>().text = scriptModificotrs.modificatores.Count.ToString();
        
    }
}

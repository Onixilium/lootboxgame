using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SetGlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var image = gameObject.GetComponentInChildren<Image>();
        Material mat = Instantiate(image.material);

        float r = Random.RandomRange(0,255), g = Random.RandomRange(0, 255), b = Random.RandomRange(0, 255);
        
        Color color = new Color(r , g , b, 0);
        mat.SetVector("_Color", color*0.05f);
        //mat.color = color;
       

        image.material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

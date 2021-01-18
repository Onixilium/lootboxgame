using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float i = 0f;
    public float addtion = -0.1f;
    // Update is called once per frame
    void Update()
    {
        i += addtion * Time.deltaTime;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(i, 0f));
    }
}

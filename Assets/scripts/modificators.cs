using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificators : MonoBehaviour
{
    public List<weapon> modificatores;
    public float multiplyModifs=0f;
    // Start is called before the first frame update
    void Start()
    {
        multiplyModifs += modificatores[0].modifMultuply;
        multiplyModifs += modificatores[1].modifMultuply;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

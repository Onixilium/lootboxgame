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
       
     //   multiplyModifs += modificatores[1].modifMultuply;
    }

    public void AddMultuply()
    {
        multiplyModifs += modificatores[0].modifMultuply;
    }
}

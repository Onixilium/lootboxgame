using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificators : MonoBehaviour
{
 

    public float speed = 0f, points = 0f, jumpForce = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
     //   multiplyModifs += modificatores[1].modifMultuply;
    }

    public void AddMultuply(weapon w)
    {
        if(w.modifCategory == weapon.modifEnum.Speed) speed+= w.modifMultuply;
        if(w.modifCategory == weapon.modifEnum.Points) points += w.modifMultuply;
        if(w.modifCategory == weapon.modifEnum.JumpTime) jumpForce += w.modifMultuply;
    }

}

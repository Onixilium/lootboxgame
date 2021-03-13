using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New weapon", menuName ="Weapon")]
public class weapon : ScriptableObject
{
    public new string name;
    public string description;
    public new string rarity;
    public Sprite art;
    public bool Opened;
    public int attack, id;

    public new string modifNameCategory;
    public float modifMultuply;
    public int modifCount;

    public void Print()
    {
        Debug.Log(name + ": " + description + " The weapon has attack " + attack);
    }
}

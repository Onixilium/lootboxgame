using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class weapon : ScriptableObject
{
    public new string name;
    public string description;
    public rarityEnum rarity;
    public Sprite art;
    public bool Opened;
    public int attack, id;

    public modifEnum modifCategory;//категория
    public float modifMultuply;//цифра категории


    public void Print()
    {
        Debug.Log(name + ": " + description + " The weapon has attack " + attack);
    }


    public enum modifEnum
    {
        Speed,
        Points,
        JumpTime
    }

    public enum rarityEnum 
    {
     common,
     rare ,
     epic,
     treasureAncientNations 
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformBehavior : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        var managerLevel = GameObject.Find("ManagerLevel").GetComponent<managerRunnerLevel>();
        speed = managerLevel.speedPlatforms;
    }
   
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
        if (transform.position.x <= -30) GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GoldKey" || col.gameObject.tag == "BronzeKey" || col.gameObject.tag == "SilverKey")  
            {
            col.collider.transform.SetParent(transform);
            col.transform.position = new Vector2(col.transform.position.x-1, col.transform.position.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    public bool onGround;
    public float jumpForce = 15f;
    private Rigidbody2D rb;
    public bool Jump;
    public GameObject DeadScreen;
    public Text textCountKeys;
    int countKeys = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Jump) BetterJump3();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            onGround = true;
            maxTime = 0.3f;
        }


        if (col.tag == "GoldKey" || col.tag == "WoodKey" || col.tag == "SilverKey")
        {
            GameObject.Find("Currency").GetComponent<Animator>().SetBool("Collected", true);
            countKeys++;
            textCountKeys.text = countKeys.ToString();
            Destroy(col.gameObject);
        }
        if (col.tag == "suriken")
        {
            DeadScreen.SetActive(true);
            GameObject.Find("Spawner").SetActive(false);
            AddKeysToCollections(countKeys);
            Destroy(gameObject);
        }
    }

    public void pointerDown()
    {
        Jump = true;
    }

    public void pointerUp()
    {
        Jump = false;
        if (!onGround) maxTime = 0f;
    }


    public float maxTime = 0.3f;

    public void BetterJump3()
    {
        maxTime -= Time.deltaTime;
        if (maxTime >= 0f)
        {
            rb.velocity = Vector2.up * jumpForce * 0.7f;
            // rb.velocity = new Vector2(rb.velocity.x,0);
            // rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//jumpForce
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            onGround = false;
        }
        else { Jump = false; }
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void AddKeysToCollections(int countKeys)
    {
        if (GameObject.Find("Collection"))
            GameObject.Find("Collection").GetComponent<Collection>().tickets += countKeys;
    }
}

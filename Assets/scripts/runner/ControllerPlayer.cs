using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    public bool isJumping = false;
    public int extraJump = 1;
    public float jumpPower;
    private Rigidbody2D rb;

    public GameObject DeadScreen;
    public Text textCountKeys;
    int countKeys = 0;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (GameObject.Find("Currency").GetComponent<Animator>().GetBool("Collected") == true) RunConter();
    }

  public  float time = 0f;
        void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            isJumping = false;
            extraJump = 1;
        }
        

        if (col.tag == "GoldKey" || col.tag == "WoodKey" || col.tag == "SilverKey" )
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


    public void Jump()
    {
        if (isJumping == true && extraJump > 0)//дополнительный прыжок
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower/2);
            extraJump--;
        }

        if (isJumping == false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            isJumping = true;
            extraJump = 1;
        }
    }


    void RunConter()
    {
        time += Time.deltaTime;
        if (time >= 1.5f) { GameObject.Find("Currency").GetComponent<Animator>().SetBool("Collected", false); time = 0; }
    }
    void AddKeysToCollections(int countKeys)
    {
        if (GameObject.Find("Collection"))
        GameObject.Find("Collection").GetComponent<Collection>().tickets += countKeys;
    }
}

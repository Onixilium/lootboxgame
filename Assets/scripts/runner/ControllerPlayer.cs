using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    public bool isJumping;
    public int extraJump = 1;
    public float jumpPower;
    private Rigidbody2D rb;

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
        if (isJumping) BetterJump3();

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            BetterJump();
        }*/

        if (GameObject.Find("Currency").GetComponent<Animator>().GetBool("Collected") == true) RunConter();
    }

   public float time = 0f;
        void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            isJumping = false;
            extraJump = 1;
            time = 0f;
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

    public bool jump2;
    public void pointerDown()
    {
        isJumping = true;         
    }

    public void pointerUp()
    {
        isJumping = false;

    }

    public float maxTime = 0.5f;
    public float timeRest = 0.2f;
    public void BetterJump3()
    {
        time += Time.deltaTime;
        if (time <= maxTime && isJumping)
        {
            rb.velocity = Vector2.up * jumpPower * 0.7f;
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }

        if (time >= (maxTime + timeRest) && isJumping) {  isJumping = false; }
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


    void Awake()
    {       
        rb = GetComponent<Rigidbody2D>();
    }
    public float fallMultiplier=2.5f,lowJumpMultiplier = 2f;
    public void BetterJump()
    {
        if (isJumping == true && extraJump > 0)//дополнительный прыжок
        {
            if (rb.velocity.y <= 0)
            {
                rb.velocity += new Vector2(0, 20) * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; ;// new Vector2(0, 2) * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0)
            {
                rb.velocity += new Vector2(0, 20) * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; // new Vector2(0, 2) * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            extraJump--;
        }

        if (isJumping == false)
        {
            if (rb.velocity.y <= 0)
            {
                rb.velocity += new Vector2(0, 20) * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; ;// new Vector2(0, 2) * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0)
            {
                rb.velocity += new Vector2(0, 20) * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; // new Vector2(0, 2) * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            isJumping = true;
            extraJump = 1;
        }
            Debug.Log(rb.velocity.y);
    }

    public void BetterJumpV2()
    {
        if (isJumping == true && extraJump > 0)//дополнительный прыжок
        {
            rb.velocity = Vector2.up * jumpPower*0.7f;
            extraJump--;
        }

        if (isJumping == false)
        {
            rb.velocity = Vector2.up * jumpPower;
            extraJump = 1;
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            isJumping = true;
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

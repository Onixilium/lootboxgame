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
    public Text TxtBronze,TxtSilver,TxtGold;
    int bronzeKeys = 0, silverKeys = 0, goldKeys = 0;


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


        if (col.tag == "BronzeKey" )
        {
            GameObject.Find("CounterBronze").GetComponent<Animator>().SetBool("Collected", true);
            bronzeKeys++;
            TxtBronze.text = bronzeKeys.ToString();
            Destroy(col.gameObject);
        }

        if (col.tag == "SilverKey")
        {
            GameObject.Find("CounterSilver").GetComponent<Animator>().SetBool("Collected", true);
            silverKeys++;
            TxtSilver.text = silverKeys.ToString();
            Destroy(col.gameObject);
        }

        if (col.tag == "GoldKey" )
        {
            GameObject.Find("CounterGold").GetComponent<Animator>().SetBool("Collected", true);
            goldKeys++;
            TxtGold.text = goldKeys.ToString();
            Destroy(col.gameObject);
        }


        if (col.tag == "suriken")
        {
            DeadScreen.SetActive(true);
            GameObject.Find("Spawner").SetActive(false);
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

    void AddKeysToCollections(int countKeys, GetRndWeapon.Chests chests)
    {
        if(chests == GetRndWeapon.Chests.bronze)      GameObject.Find("Collection").GetComponent<Collection>().quantityBronzeKey += countKeys;

        if (chests == GetRndWeapon.Chests.silver)   GameObject.Find("Collection").GetComponent<Collection>().quantitySilverKey += countKeys;

        if (chests == GetRndWeapon.Chests.gold)     GameObject.Find("Collection").GetComponent<Collection>().quantityGoldKey += countKeys;

    }

   bool slide = false;
   public void ButtonSliding()
    {
        var collider = gameObject.GetComponent<BoxCollider2D>();
        if (!slide)
        {            
            collider.offset = new Vector2(0.1983056f, -0.4830694f);
            collider.size = new Vector2(1.176949f, 0.6693335f);
            slide = true;
        }
        else
        {
            collider.offset = new Vector2(0.1983056f, 0.2905495f);
            collider.size = new Vector2(1.176949f, 2.216571f);            
            slide = false;
        }
        gameObject.GetComponent<Animator>().SetBool("Slide", slide);
    }

}

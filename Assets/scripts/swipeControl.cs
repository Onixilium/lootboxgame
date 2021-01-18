using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipeControl : MonoBehaviour
{
    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    private float displayTime = 0.3f;
    public GameObject Gorila;
    public int column = 2;//1 Left 2 middle 3 right
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float startX, endX;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            phaseDisplayText.text = theTouch.phase.ToString();

            if (theTouch.phase == TouchPhase.Began)
                startX = theTouch.position.x;

             if (theTouch.phase == TouchPhase.Ended)
            {
                endX = theTouch.position.x;
                timeTouchEnded = Time.time;
            }
        }

      

        else if (Time.time - timeTouchEnded > displayTime)
        {
            if (startX < endX) { if (column < 3) { phaseDisplayText.text = ">"; Gorila.transform.position = new Vector3(Gorila.transform.position.x + (GameObject.Find("Canvas").transform.localScale.x * 800 / 3), Gorila.transform.position.y); column++; startX = 0; endX = 0; } }
            if (startX > endX) { if (column > 1) { phaseDisplayText.text = "<"; Gorila.transform.position = new Vector3(Gorila.transform.position.x - (GameObject.Find("Canvas").transform.localScale.x * 800 / 3), Gorila.transform.position.y); column--; startX = 0; endX = 0; } }

            phaseDisplayText.text = "";
        }
    }
}

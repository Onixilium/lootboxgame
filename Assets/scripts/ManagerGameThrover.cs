using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGameThrover : MonoBehaviour
{

    public float time = 0f;
    public Button surekenButtonPrefab;

    // Update is called once per frame
    public float spawnTime=0.5f;
    
    void Update()
    {
        time += Time.deltaTime;
        if(time> spawnTime)
        {
            Button newSureken = (Button)Instantiate(surekenButtonPrefab);
            if (gameObject.name == "sureken") { SurekenControl(newSureken); }
            if (gameObject.name == "banana") { BananaControl(newSureken);  }
            time = 0f;
        }
       
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {                
                print(touch.phase);
            }
        }
    }

    private void SurekenControl(Button newSureken)
    {
        newSureken.GetComponent<randomMoving>().dx = Random.Range(0, 2);
        newSureken.GetComponent<randomMoving>().dx2 = Random.Range(-2, 0);
        newSureken.GetComponent<randomMoving>().dy = Random.Range(-2, -1);
        newSureken.GetComponent<randomMoving>().dy2 = Random.Range(-2, -1);
        GameObject canvas = GameObject.Find("Canvas");
        newSureken.transform.SetParent(canvas.transform, false);
        newSureken.transform.localPosition = new Vector2(Random.Range(100, 700), 800);
        print(GameObject.Find("Canvas").transform.localScale.y * 800);
    }

    private void BananaControl(Button banana)
    {
        GameObject canvas = GameObject.Find("Canvas");
        banana.transform.SetParent(canvas.transform, false);
        banana.transform.localPosition = new Vector2(Random.Range(100, 700), 800);
        print(GameObject.Find("Canvas").transform.localScale.y * 800);
    }
}

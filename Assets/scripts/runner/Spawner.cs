using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float time = 0f;
    public GameObject[] platform = new GameObject[2];
    GameObject  newPlatform, newKey;
    public GameObject[] keys = new GameObject[3];

    public float minTimeSpawn=.5f, maxTimeSpawn=3f, Mindevation, Maxdevation;
    float devationHieght = 0f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= Random.Range(minTimeSpawn, maxTimeSpawn))
        {
            int rand = Random.Range(0, 100);
            int currentPlatform = 0;
            devationHieght = Random.Range(Mindevation, Maxdevation);
            if (rand > 25) currentPlatform = 0;
           /* if(rand>55) newKey = Instantiate(keys[Random.Range(0, 3)], new Vector2(12f, 0f), Quaternion.identity);
            if (rand <= 10) currentPlatform = 1; */

            newPlatform = Instantiate(platform[currentPlatform], new Vector2(14.13f, -5.45f + devationHieght), Quaternion.identity); //currentPlatform вместо 0 и  devationHieght вместо 0 после плюса

            time = 0f;
        }
    }
}
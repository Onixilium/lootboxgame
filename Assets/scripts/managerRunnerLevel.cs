using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerRunnerLevel : MonoBehaviour
{
    public float minTimeSpawn, maxTimeSpawn;
    public float jumpForce;
    public float speedPlatforms;

    public float scores;
    SetUiText setUiText;
    modificators modificators;
    // Start is called before the first frame update
    void Start()
    {
        var spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        spawner.minTimeSpawn = this.minTimeSpawn;
        spawner.maxTimeSpawn = this.maxTimeSpawn;

        var player = GameObject.Find("PLAYER").GetComponent<ControllerPlayer>();
        player.jumpForce = this.jumpForce;

        setUiText = GetComponent<SetUiText>();

        modificators = GameObject.Find("Collection").GetComponent<modificators>();

    }

    float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            scores += 100 * modificators.multiplyModifs;
            setUiText.SetScoresRunner(scores);
            time = 0f;
        }
    }
}

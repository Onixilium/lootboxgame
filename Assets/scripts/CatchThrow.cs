using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchThrow : MonoBehaviour
{
    public Text ticketsText;
    public void selfDestroyandAddCoin()
    {
        Destroy(gameObject);
        GameObject.Find("Collection").GetComponent<Collection>().tickets++;

        ticketsText = GameObject.Find("TextTickets").GetComponent<Text>();
        ticketsText.text = GameObject.Find("Collection").GetComponent<Collection>().tickets.ToString();
    }
}

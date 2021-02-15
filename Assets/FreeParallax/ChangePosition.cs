using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{

    void Update()
    {
        if (gameObject.transform.position.x <= -22f) gameObject.transform.position = new Vector3(42f,-0.1f,1f);
    }
}

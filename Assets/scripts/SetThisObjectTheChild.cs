using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetThisObjectTheChild : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="key")
            col.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
      /*   if(col.gameObject.tag=="ground")
            col.collider.transform.SetParent(null);*/
    }
}

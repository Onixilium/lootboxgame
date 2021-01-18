using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomMoving : MonoBehaviour
{
    public float speed = 2;//7

    public int typeMove;
    void Start()
    {
       //случайное движение
    }
    private Vector3 _startPosition;

    void Update()
    {
        _startPosition = transform.position;
        if (typeMove==1)        MoveSinus();
        if (typeMove==2)        MoveForward();
        if (transform.position.y <= -1318) Destroy(gameObject);
    }
    float time = 0f;

    public float dx,dy,dx2,dy2;
    public void MoveSinus()
    {
        time += Time.deltaTime;

        if (time <= 0.5f)
        {
            transform.Translate(new Vector3(dx, dy) * Time.deltaTime*speed);

        }
        if (time >= 0.5f)
        {
            transform.Translate(new Vector3(dx2,dy2) * Time.deltaTime * speed);
        }

        if (time >= 1f) time = 0;
    }


    public void MoveForward()
    {
        transform.Translate(new Vector3(dx, dy) * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "castle")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "border")
        {
            Destroy(gameObject);
        }
    }









    public enum directions
    {
        up,
        down,
        left,
        right
    }
}

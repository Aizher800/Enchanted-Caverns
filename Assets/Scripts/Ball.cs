using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Ball Collided Enemy");
        }


        if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
            //Debug.Log("Ball Collided Wall");
        }
    }

}

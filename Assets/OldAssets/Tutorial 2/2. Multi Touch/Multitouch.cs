using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Multitouch : MonoBehaviour
{
    public GameObject fireballPrefab;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];
                Vector3 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
                touchposition.z = 0.0f;

                if (i == 0)
                {
                    transform.position = (Vector2)touchposition;
                }

                else

                {
                    GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
                    Rigidbody2D rb2d = fireball.GetComponent<Rigidbody2D>();
                    rb2d.velocity = (Vector2)(touchposition - transform.position) * 3.0f;
                }
            }
        }
    }
}

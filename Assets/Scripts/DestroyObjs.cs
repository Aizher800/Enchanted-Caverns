using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjs : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

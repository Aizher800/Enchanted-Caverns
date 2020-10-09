using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLoot : MonoBehaviour
{
    public GameObject coins;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            Instantiate(coins, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}

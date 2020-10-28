using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLoot : MonoBehaviour
{
    public GameObject dropLoot;
    private int health = 1;

    public void DmgDealt()
    {
        health--; // any obj that triggers it to lose health, will drop its health
        CheckDeath();
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject); // destroys object with no health after taking dmg
            Instantiate(dropLoot, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Ammo")
        {
            DmgDealt();
        }
    }

}

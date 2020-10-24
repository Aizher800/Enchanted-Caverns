using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStats : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject dropLoot;

    public TextMeshProUGUI textHealth;

    void Start()
    {
        health = maxHealth;   //sets up max health upon start of game
    }

    private void Update()
    {
        textHealth.text = health.ToString();
    }

    public void DmgDealt()
    {
        health--; // any obj that triggers it to lose health, will drop its health
        CheckDeath();
    }
    private void HealEnemy()
    {
        health++;
        healthOverheal();
    }

    private void healthOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth; // if object gets healed, can only heal till maxHealth (can't get over 11 if 10 is maxHealth)
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject); // destroys object with no health after taking dmg
            Instantiate(dropLoot, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            HealEnemy(); 
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Ammo")
        {
            DmgDealt();
            CheckDeath();
        }
    }
}

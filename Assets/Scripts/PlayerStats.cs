using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;

    public GameObject player;
    public static float health;
    public static float maxHealth = 5f;
    public TextMeshProUGUI textHealth;

    public GameObject Canvas;
    public GameObject mainCamera;
    public GameObject spawnPoint;


    //public GameObject globalLight;

    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        textHealth.text = health.ToString();
    }

    public void DmgDealt()
    {
        health--; // any obj that triggers it to lose health, will drop its health
        CheckDeath();
    }

    private void HealPlayer()
    {
        health++;
        healthOverheal();
    }

    public void ShopHeal()
    {
        health = maxHealth;
    }

    private void healthOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth; // if object gets healed, can only heal till maxHealth or it will be ignored
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(Canvas);
            Destroy(player);
            Destroy(mainCamera);
            Destroy(spawnPoint);
            //Destroy(globalLight);
            SceneManager.LoadScene("Game Over");
        }
    }

    private void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.transform.tag == "Enemy")
        {
            DmgDealt();
        }

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Potion")
        {
            if (health == 5)
            {
                //do nothing
            }
            else 
            {
                //destroy potion, heal player
                HealPlayer();
                Destroy(coll.gameObject);
            }
            
        }
    }
}

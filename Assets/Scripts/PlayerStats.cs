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
    public float health;
    public float maxHealth;
    public TextMeshProUGUI textHealth;

    void Start()
    {
        health = maxHealth;   //sets up max health upon start of game
        textHealth.text = health.ToString();
    }

    public void DmgDealt(float damage)
    {
        health -= damage; // any obj that triggers it to lose health, will drop its health
        CheckDeath();
    }

    private void HealPlayer(float heal)
    {
        health += heal;
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
            Destroy(player); // destroys object with no health after taking dmg
        }
    }
}

﻿using System.Collections;
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

    public int coins = 0;
    public int index = 1;
    public TextMeshProUGUI textCoins;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Coin")
        {
            coins++;
            textCoins.text = coins.ToString();
            Debug.Log(coins);
        }
        if (other.transform.tag == "Door")
        {
            index++;
            SceneManager.LoadScene(index);
            Debug.Log("You're in Level " + index);
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
}

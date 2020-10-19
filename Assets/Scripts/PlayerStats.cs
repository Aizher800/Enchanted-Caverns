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

    public GameObject Canvas;
    public GameObject mainCamera;
    public GameObject spawnPoint;

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
            SceneManager.LoadScene("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.transform.tag == "Enemy")
        {
            DmgDealt();
        }
    }
}

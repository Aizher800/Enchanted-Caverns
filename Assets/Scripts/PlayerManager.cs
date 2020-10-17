using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public int coins = 0;
    private int index = 1;
    public int key;
    public Transform respawnLocation;
    public TextMeshProUGUI textCoins;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Coin")
        {
            coins++;
            textCoins.text = coins.ToString(); // stores coins
            //Debug.Log(coins);
        }
        if (other.transform.tag == "Door")
        {
            if (key == 1) // getting a key will unlock the door, which will remove the key and bring player to the next level and teleporting the player to a spawn point
            {
                key--;
                Debug.Log("Keys= " + key);
                index++;
                SceneManager.LoadScene(index);
                player.transform.position = respawnLocation.position;
                //Debug.Log("You're in Level " + index);
            }
            else
            {
                Debug.Log("You are missing a key"); // can't get through door without key
            }
        }
        if (other.transform.tag == "Key") // collects keys
        {
            key++;
            Debug.Log("Keys= " + key);
        }
        DontDestroyOnLoad(this.gameObject); // keep this object when moving to different scenes
    }
}

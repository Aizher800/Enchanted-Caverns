using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject DoorUI;
    private bool isLocked;
    private float doorCountdown = 0f;
    private float doorTimer = 3f;
    private static float Key;



    void Start()
    {
        DoorUI.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {

            if (Key == 0)
            {
                doorCountdown = doorTimer;
                isLocked = true;
                Locked();
            }
        }
    }

    void Locked()
    {
        if (isLocked)
        {
            DoorUI.SetActive(true);

        }
    }
    void Update()
    {
        Key = PlayerManager.key;
        if (doorCountdown > 0f)
        {
            doorCountdown -= Time.deltaTime;
            DoorUI.SetActive(true);
        }
        else
        {
            DoorUI.SetActive(false);
        }

    }
}

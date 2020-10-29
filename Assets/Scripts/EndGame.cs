using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI textCoins;
    public static int Coins;

    void Start()
    {
        
    }public static int coins = 0;


    void Update()
    {
        Coins = PlayerManager.coins;
        textCoins.text = Coins.ToString();
    }
}

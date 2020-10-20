﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelAndShopUI : MonoBehaviour
{
    public GameObject shopTab;
    public GameObject ClearLvlUI;
    public int index = 1;

    public void shopOpen()
    {
        shopTab.SetActive(true);
    }

    public void continueLevel()
    {
        index++;
        SceneManager.LoadScene(index);
        ClearLvlUI.SetActive(false);
        shopTab.SetActive(false);
    }
}

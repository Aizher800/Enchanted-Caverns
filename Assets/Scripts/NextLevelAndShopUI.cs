using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelAndShopUI : MonoBehaviour
{
    public GameObject shopTab;
    public GameObject ClearLvlUI;
    //public GameObject AdUI;
    private int index = 1;

    public void shopOpen()
    {
        shopTab.SetActive(true);
        //AdUI.SetActive(true);
        ClearLvlUI.SetActive(false);
    }

    public void continueLevel()
    {
        index++;
        SceneManager.LoadScene(index);
        ClearLvlUI.SetActive(false);
        shopTab.SetActive(false);
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject Camera;
    public GameObject Canvas;
    public GameObject Player;

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        DoNotKeep();

    }

    public void ExitGame()
    {
        Debug.Log("You've clicked Exit!");
        Application.Quit();
    }

    public void DoNotKeep()
    {
        Destroy(Camera);
        Destroy(Canvas);
        Destroy(Player);
    }
}

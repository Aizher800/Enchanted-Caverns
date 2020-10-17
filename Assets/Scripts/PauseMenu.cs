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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
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
        Destroy(Camera);
        Destroy(Canvas);
        Destroy(Player);
    }

    public void ExitGame()
    {
        Debug.Log("You've clicked Exit!");
        //Application.Quit();
    }
}

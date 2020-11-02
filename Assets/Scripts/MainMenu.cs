using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public GameObject tutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        //Debug.Log("You've clicked Start Game!");
        SceneManager.LoadScene(1);
    }

    public void OpenTutorial()
    {
        //Debug.Log("You've opened Tutorial!");
    tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        //Debug.Log("You've closed Tutorial!");
    tutorialPanel.SetActive(false);
}

    public void ExitGame()
    {
        Debug.Log("You've clicked Exit!");
        Application.Quit();
    }
}

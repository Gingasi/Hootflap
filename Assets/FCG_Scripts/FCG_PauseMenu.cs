using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FCG_PauseMenu : MonoBehaviour
{
   

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;


    void Start() //If its not established that every time this script is up that the game is on (GameIsPaused =false) the game will be stoped every time you go back to your menu.
    {
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);

    }
    void Update()  /*Everytime the player press esc a pop up message will appear. This script is created in case i made an option menu. It was not necessary in this ocasion. */
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
       
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;

    }

    public void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Option Menu");

    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FCG_MoveBetweenScene : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Starts()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Quit()
    {
        Debug.Log("QuitGame");
        Application.Quit();

    }

    public void GoBackMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


}

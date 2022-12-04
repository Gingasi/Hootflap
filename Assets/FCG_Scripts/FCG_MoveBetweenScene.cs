using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FCG_MoveBetweenScene : MonoBehaviour
{
    public void Starts()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void Quit()
    {
        Debug.Log("QuitGame");
        Application.Quit();

    }
}

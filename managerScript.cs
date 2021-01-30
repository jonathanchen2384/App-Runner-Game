using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void selectChar()
    {
        SceneManager.LoadScene("Select");
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void goBack()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void goCredits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }
}

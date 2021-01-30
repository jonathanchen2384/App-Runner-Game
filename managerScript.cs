using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void selectChar()
    {
        SceneManager.LoadScene("Select");
    }

    public void restart()
    {
        SceneManager.GetActiveScene();
    }

    public void goBack()
    {
        SceneManager.LoadScene("Menu");
    }
}

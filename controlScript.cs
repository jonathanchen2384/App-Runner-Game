using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlScript : MonoBehaviour
{
    public float adjuster;
    private float timeSave;

    void Update()
    {
        if (Time.timeScale <= 2.5 && Time.timeScale > 0)
        {
            Time.timeScale += Time.deltaTime*adjuster;
        }
    }

    public void puaseGame()
    {
        if (Time.timeScale != 0)
        {
            timeSave = Time.timeScale;
            Time.timeScale = 0;
        }

        else {
            Time.timeScale = timeSave;
        }
    }
}

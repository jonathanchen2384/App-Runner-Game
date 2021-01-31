using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlScript : MonoBehaviour
{
    public float maxSpeed;
    public float adjuster;
    private float timeSave;
    public GameObject overScene;
    GameObject Obj;

    void Update()
    {
        if (Time.timeScale <= maxSpeed && Time.timeScale > 0)
        {
            Time.timeScale += Time.deltaTime*adjuster;
        }
    }

    public void puaseGame()
    {
        if (Time.timeScale != 0)
        {
            Obj = (GameObject)Instantiate(overScene, transform.position, Quaternion.identity);
            timeSave = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;
        }

        else {
            Destroy(Obj);
            Time.timeScale = timeSave;
            AudioListener.pause = false;
        }
    }
}

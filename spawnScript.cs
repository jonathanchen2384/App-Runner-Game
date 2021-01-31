using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject powerUp;

    public float startTime;
    private float duration;

    private float level;
    private int count;

    private bool enterBoss;

    void Start()
    {
        enterBoss = false;
        count = 0;
        duration = startTime;
        level = 1;
    }

    void Update()
    {
        if (count%10 == 0 && count != 0)
        {
            level = 1.5f;
        }

        if (duration <= 0 && enterBoss == false)
        {
            if (level == 1) // normal
            {
                Instantiate(obstacles[(int)Random.Range(0, obstacles.Length)], transform.position, Quaternion.identity);
                count++;
                duration = startTime;
            }

            if (level == 1.5f) //power UP
            {
                Instantiate(powerUp, transform.position, Quaternion.identity);
                count++;
                level = 1;
                duration = startTime;
            }
        }

        else {
           duration -= Time.deltaTime;
        }
    }
}

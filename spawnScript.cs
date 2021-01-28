using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject obstacles;

    public float startTime;
    private float duration;

    void Start()
    {
        duration = startTime;
    }

    void Update()
    {
        if (duration <= 0)
        {
            Instantiate(obstacles, transform.position, Quaternion.identity);
            duration = startTime;
        }

        else {
            duration -= Time.deltaTime;
        }
    }
}

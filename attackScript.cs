using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public int powerCheck;
    public Transform playerPos;

    public GameObject[] powerSort;

    public GameObject[] playerSort;
    public GameObject playerAlive;


    void Start()
    {
        powerCheck = PlayerPrefs.GetInt("Power", 1);
    }

    public void attack()
    {
        playerPowerKind(powerCheck);
    }

    public void playerPowerKind(int powerKind)
    {
        if (playerAlive.GetComponent<playerScript>().health > 0)
        {
            Instantiate(powerSort[powerKind-1], playerSort[powerKind-1].transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSetUp : MonoBehaviour
{
    public int playerHearts;
    public int playerPower;


    void Start()
    {
        playerHearts = 3;
        playerPower = 1;
    }

    void Update()
    {
        if (playerHearts <= 0 || playerPower <= 0)
        {
            playerHearts = 3;
            playerPower = 1;
            Debug.Log("Default - player 1");
        }
    }


    public void playerOne() // player 1
    {
        playerHearts = 3;
        playerPower = 1;
        Debug.Log("player 1");
    }


    public void playerTwo() // player 2
    {
        playerHearts = 2;
        playerPower = 2;
        Debug.Log("player 2");
    }


    public void playerThree() // player 3
    {
        playerHearts = 5;
        playerPower = 3;
        Debug.Log("player 3");
    }
}

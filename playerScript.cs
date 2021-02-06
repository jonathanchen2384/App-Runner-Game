using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{

    public GameObject[] player;

    //hearts
    public int health;
    public int numHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // pause button
    public GameObject overScene;
    public GameObject pauseObj;

    private Vector2 mousePos;

    public bool isClick;
    public Transform[] checkerPos;

    public int playerID;

    public void Awake()
    {
        numHearts = PlayerPrefs.GetInt("Hearts", 3);
        playerID = PlayerPrefs.GetInt("Power", 1);
    }

    void Start()
    {
        health = numHearts;

        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //pause position

        if (mousePos.x >= checkerPos[0].position.x && mousePos.y >= checkerPos[0].position.y)
        {
            isClick = false;
        }

        //attack position

        if (mousePos.x >= checkerPos[1].position.x && mousePos.y >= checkerPos[1].position.y)
        {
            if (mousePos.x <= checkerPos[2].position.x && mousePos.y <= checkerPos[2].position.y)
            {
                isClick = false;
            }
        }

        //everywhere else

        else
        {
            isClick = true;
        }
    }

    void Update()
    {
        identifyPlayer();
        powerUpChecker();
        playerHealth();

        if (health <= 0)
        {
            Destroy(pauseObj);
            Instantiate(overScene, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    public void powerUpChecker()
    {
        if (GetComponent<collectionScript>().powered == true)
        {
            health = numHearts;
            GetComponent<collectionScript>().powered = false;
        }
    }



    public void playerHealth()
    {
        if (health > numHearts)
        {
            health = numHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void identifyPlayer()
    {
        if (playerID == 1)
        {
            player[0].SetActive(true);
        }

        else if (playerID == 2)
        {
            player[1].SetActive(true);
        }

        else if (playerID == 3)
        {
            player[2].SetActive(true);
        }

        else
        {
            player[0].SetActive(true);
        }
    }
}

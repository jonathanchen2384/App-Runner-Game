using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{

    public GameObject[] player;

    public Rigidbody2D RB;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float radius;
    public LayerMask ground;

    public int totalJumps;
    private int extrajumps;

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

    bool isClick;
    public Transform[] checkerPos;

    //steps
    public float startTime;
    private float duration;
    public GameObject stepOne;

    private float durationTwo;
    public GameObject stepTwo;

    // jump Sound
    public GameObject jumpSound;

    public int playerID;


    public Animator Anim;



    public void Awake()
    {
        numHearts = PlayerPrefs.GetInt("Hearts", 3);
        health = numHearts;

        playerID = PlayerPrefs.GetInt("Power", 1);
    }

    void Start()
    {
        Anim.SetBool("isJumping", false);


        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(false);
        }

        extrajumps = totalJumps;
        isClick = true;

        duration = startTime;
        durationTwo = startTime * 1.5f;
    }

    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //pause position

        if (mousePos.x >= checkerPos[0].position.x && mousePos.y >= checkerPos[0].position.y)
        {
            isClick = false;
        }

        //atack position

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

        //footsteps
        if (isGrounded == true)
        {
            RunSound();
            Anim.SetBool("isJumping", false);
        }
    }

    void Update()
    {
        identifyPlayer();

        isGrounded = Physics2D.OverlapCircle(feetPos.position, radius, ground);

        if (isGrounded == true && Input.GetMouseButtonDown(0))
        { // jump
            if (isClick == true)
            {
                Instantiate(jumpSound, transform.position, Quaternion.identity);
                extrajumps = totalJumps;
                RB.velocity = Vector2.up * jumpForce;
                Anim.SetBool("isJumping", true);
            }
        }

        if (isGrounded == false && extrajumps > 0)
        {
            if (Input.GetMouseButtonDown(0) && isClick == true)
            {
                Instantiate(jumpSound, transform.position, Quaternion.identity);
                RB.velocity = Vector2.up * jumpForce;
                extrajumps--;
                Anim.SetBool("isJumping", true);
            }
        }

        playerHealth();

        if (health <= 0)
        {
            Destroy(pauseObj);
            Instantiate(overScene, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        powerUpChecker();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && health > 0)
        {
            health--;
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


    public void powerUpChecker()
    {
        if (GetComponent<collectionScript>().powered == true)
        {
            health = numHearts;
            GetComponent<collectionScript>().powered = false;
        }
    }


    public void RunSound()
    {
        duration -= Time.deltaTime;
        durationTwo -= Time.deltaTime;


        if (duration <= 0) //step One
        {
            Instantiate(stepOne, transform.position, Quaternion.identity);
            duration = startTime;
        }

        if (durationTwo <= 0) //step Two
        {
            Instantiate(stepTwo, transform.position, Quaternion.identity);
            durationTwo = startTime;
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

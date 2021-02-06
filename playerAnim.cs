using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class playerAnim : MonoBehaviour
{
    public GameObject PlayerManager;

    //jump
    public Rigidbody2D RB;
    public float jumpForce;

    public bool isGrounded;
    public Transform feetPos;
    public float radius;
    public LayerMask ground;

    public int totalJumps;
    private int extrajumps;

    public bool checkClick;

    //steps
    public float startTime;
    private float duration;
    public GameObject stepOne;

    private float durationTwo;
    public GameObject stepTwo;

    // jump Sound
    public GameObject jumpSound;

    // animation
    public Animator Anim;

    void Start()
    {
        duration = startTime;
        durationTwo = startTime * 1.5f;

        extrajumps = totalJumps;
        Anim.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        checkClick = PlayerManager.GetComponent<playerScript>().isClick;

        //footsteps
        if (isGrounded == true)
        {
            RunSound();
            Anim.SetBool("isJumping", false);
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, radius, ground);

        if (isGrounded == true && Input.GetMouseButtonDown(0))
        { // jump
            if (checkClick == true)
            {
                Instantiate(jumpSound, transform.position, Quaternion.identity);
                extrajumps = totalJumps;
                RB.velocity = Vector2.up * jumpForce;
                Anim.SetBool("isJumping",true);
            }
        }

        if (isGrounded == false && extrajumps > 0)
        {
            if (Input.GetMouseButtonDown(0) && checkClick == true)
            {
                Instantiate(jumpSound, transform.position, Quaternion.identity);
                RB.velocity = Vector2.up * jumpForce;
                extrajumps--;
                Anim.SetBool("isJumping", true);
            }
        }
    }

    // GIZMOS

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position, radius);
    }


    // SFX Running

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


    // Collider For Player Manager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && PlayerManager.GetComponent<playerScript>().health > 0)
        {
            PlayerManager.GetComponent<playerScript>().health--;
        }

        if (collision.CompareTag("Coin"))
        {
            PlayerManager.GetComponent<collectionScript>().coins++;
            PlayerPrefs.SetInt("Coins", PlayerManager.GetComponent<collectionScript>().coins);
            PlayerPrefs.Save();
        }

        if (collision.CompareTag("Gem"))
        {
            PlayerManager.GetComponent<collectionScript>().gems++;
            PlayerPrefs.SetInt("Gems", PlayerManager.GetComponent<collectionScript>().gems);
            PlayerPrefs.Save();
        }

        if (collision.CompareTag("Power"))
        {
            PlayerManager.GetComponent<collectionScript>().powered = true;
        }
    }
}

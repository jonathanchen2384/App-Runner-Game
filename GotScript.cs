using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotScript : MonoBehaviour
{
    private bool isGot = false;

    public float speed;

    public SpriteRenderer clear;
    private float trans;

    public float timeLeft;
    private float initialTime;
    public float termin;

    private void Start()
    {
        initialTime = timeLeft;
    }

    void Update()
    {
        if (isGot == true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            clear.material.color = new Color(1f, 1f, 1f, timeLeft/initialTime);

            if (timeLeft <= 0)
            {
                Destroy(gameObject, termin);
            }

            else
            {
                timeLeft -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isGot = true;
        }
    }
}

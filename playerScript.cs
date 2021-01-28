using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float radius;
    public LayerMask ground;

    public int totalJumps;
    private int extrajumps;

    void Start()
    {
        extrajumps = totalJumps;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, radius, ground);

        if ( isGrounded == true && Input.GetMouseButtonDown(0)) {
            extrajumps = totalJumps;
            RB.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == false && extrajumps > 0) {
            if (Input.GetMouseButtonDown(0)) {
                RB.velocity = Vector2.up * jumpForce;
                extrajumps--;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position, radius);
    }
}

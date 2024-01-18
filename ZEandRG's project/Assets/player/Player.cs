using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 3f;
    public int jumpLimit = 2;
    private int jumpCount = 0;
    private Rigidbody2D rb;
    private SpriteRenderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 플레이어 이동
        playerMove();
        playerJump();
    }
    void playerMove() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        if (horizontalInput > 0)
        {
            rend.flipX= false;
        }
        else if(horizontalInput < 0)
        {
            rend.flipX= true;
        }
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }
    void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpCount < jumpLimit)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            jumpCount = 0;
        }
    }
}

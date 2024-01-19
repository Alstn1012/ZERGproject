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
    private Animator anim; // 에니메이터 변수 선언

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); // 에니메이터 변수
    }

    void Update()
    {
        playerMove();
        playerJump();

        float horizontalInput = Input.GetAxis("Horizontal");

        // 플레이어가 움직일 때
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // 달리기 애니메이션 재생
            anim.SetBool("run", true);
        }
        else
        {
            // 가만히 있을 때
            anim.SetBool("run", false);
        }
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
                anim.SetBool("jump", true); // 점프 시 에니메이션 
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            jumpCount = 0;
            anim.SetBool("jump", false); // 비 점프 상태 전환
        }
    }
}

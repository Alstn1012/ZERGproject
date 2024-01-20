using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 3f;
    public int jumpLimit = 2;
    private int jumpCount = 0;

    private bool canDash = true;
    private float dashPower = 25f;
    private float dashingTime = 0.2f;
    private float dashCool = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Animator anim; // 에니메이터 변수 선언
    [SerializeField] private TrailRenderer trail;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); // 에니메이터 변수
    }

    void Update()
    {
        if (playerStatus.instance.isDash)
        {
            return;
        }
        playerMove();
        playerJump();
        playerDash();

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
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
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
    void playerDash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)&&canDash)
        {
            StartCoroutine(dash());
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
    private IEnumerator dash()
    {
        canDash = false;
        playerStatus.instance.isDash= true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        rb.gravityScale = originalGravity;
        playerStatus.instance.isDash= false;
        yield return new WaitForSeconds(dashCool);
        canDash= true;
    }
}

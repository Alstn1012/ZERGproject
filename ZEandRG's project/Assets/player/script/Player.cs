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
    public float dashPower = 30f;
    public float dashingTime = 0.15f;
    public float dashCool = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Animator anim; // ���ϸ����� ���� ����
    public GameObject pos;
    [SerializeField] private TrailRenderer trail;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); // ���ϸ����� ����
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
        // �÷��̾ ������ ��
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // �޸��� �ִϸ��̼� ���
            anim.SetBool("run", true);
        }
        else
        {
            // ������ ���� ��
            anim.SetBool("run", false);
        }
}
    void playerMove() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            pos.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            pos.transform.rotation = Quaternion.Euler(0, -1, 0);
        }
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }
    void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpCount < jumpLimit)
            {
                playerStatus.instance.isJump = true;
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpCount++;
                anim.SetBool("jump", true); // ���� �� ���ϸ��̼� 
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
            playerStatus.instance.isJump = false;
            jumpCount = 0;
            anim.SetBool("jump", false); // �� ���� ���� ��ȯ
        }
    }
    private IEnumerator dash()
    {
        canDash = false;
        playerStatus.instance.isDash = true;
        if (playerStatus.instance.invincibleTime==0f)
        {
            playerStatus.instance.whileInvincible = true;
        }
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        rb.gravityScale = originalGravity;
        if (playerStatus.instance.invincibleTime == 0f)
        {
            playerStatus.instance.whileInvincible = false;
        }
        playerStatus.instance.isDash= false;
        yield return new WaitForSeconds(dashCool);
        canDash= true;
    }
}

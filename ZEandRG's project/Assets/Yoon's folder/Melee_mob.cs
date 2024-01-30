using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_mob : MonoBehaviour
{
    public float speed = 1.75f;
    public float stoppingDistance = 2f;
    public float attackRange = 1f;
    public float attackCooldown = 0.75f; // ���� ���� ��ٿ� �ð�
    private float nextAttackTime = 0f;

    public Transform player;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < stoppingDistance)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown; 
            }
        }
        else if (distanceToPlayer > stoppingDistance)
        {
            // �÷��̾ ������ ���� �ִϸ��̼� ����
            animator.SetBool("run", true);

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        playerStatus.instance.playerHp -= 1;
        Debug.Log("���� ����!");
    }
}

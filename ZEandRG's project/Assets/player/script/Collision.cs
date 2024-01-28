using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public float invincibleTimeLimit=1f;
    private float blinkTime;
    private bool isAttacked;
    private void blink(float limit)
    {
        if (blinkTime < limit/8.0f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            if (blinkTime > limit/4.0f)
            {
                blinkTime = 0;
            }
        }
        blinkTime += Time.deltaTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet")
        {
            if (playerStatus.instance.whileInvincible == false)
            {
                collision.gameObject.SetActive(false);
                playerStatus.instance.playerHp -= 1;
                playerStatus.instance.whileInvincible = true;
                isAttacked = true;
            }
        }
    }
    void Start()
    {
        isAttacked= false;
    }
    void Update()
    {
        if (isAttacked == true)
        {
            if (playerStatus.instance.invincibleTime < invincibleTimeLimit)
            {
                playerStatus.instance.invincibleTime += Time.deltaTime;
                blink(invincibleTimeLimit);
            }
            else
            {
                playerStatus.instance.invincibleTime = 0;
                playerStatus.instance.whileInvincible = false;
                isAttacked = false;
            }
        }
    }
}

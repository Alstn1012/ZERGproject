using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public float invincibleTimeLimit=1f;
    private float invincibleTime;
    private float blinkTime;
    private void blink(float limit)
    {
        if (blinkTime < limit/8.0f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - 0.6f);
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
                Destroy(collision.gameObject);
                playerStatus.instance.playerHp -= 1;
                playerStatus.instance.whileInvincible = true;
            }
        }
    }
    void Update()
    {
        if (playerStatus.instance.whileInvincible== true)
        {
            if (invincibleTime < invincibleTimeLimit)
            {
                invincibleTime += Time.deltaTime;
                blink(invincibleTimeLimit);
            }
            else
            {
                invincibleTime= 0;
                playerStatus.instance.whileInvincible= false;
            }
        }
    }
}

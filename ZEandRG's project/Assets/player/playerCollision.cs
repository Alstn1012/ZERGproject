using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            playerStatus.instance.whileInvincible = true;
            playerStatus.instance.playerHp -= 1;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}

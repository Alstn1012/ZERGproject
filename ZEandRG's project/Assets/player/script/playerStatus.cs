using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    public bool isAlive;
    public bool whileInvincible;
    public bool isDash;
    public bool ispanelActive;
    public bool isMapChange;
    public bool pausePanelOff;
    public bool exitPanelOff;
    public float invincibleTime;
    public int playerHpLimit = 3;
    public int playerHp=3;
    public GameObject player;
    public static playerStatus instance;
    private void Awake()
    {
        if(playerStatus.instance == null)
        {
            playerStatus.instance = this;
        }
    }
    void Start()
    {
        isAlive= true;
        isDash= false;
        whileInvincible= false;
        invincibleTime= 0f;
    }
    void Update()
    {
        if (playerHp == 0)
        {
            isAlive= false;
            Destroy(player);
        }
    }
}

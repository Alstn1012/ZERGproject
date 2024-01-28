using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemap : MonoBehaviour
{
    [SerializeField] ObjectArrayExample chooseRandomRoom;
    public bool movemap = false;
    //public bool movemap = false;
    public bool isActive = false;
    public GameObject ExitPanel;
    public GameObject background;
    private void active()
    {
        ExitPanel.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 0f;
        playerStatus.instance.ispanelActive = true;
        isActive = true;
    }
    private void resume()
    {
        ExitPanel.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1.0f;
        playerStatus.instance.ispanelActive = false;
        isActive = false;
    }
    private void moveMap()
    {
        movemap = true;
        /*chooseRandomRoom = GameObject.Find("ObjectArrayExample").GetComponent<ObjectArrayExample>();
        chooseRandomRoom.Tag = "Room";
        chooseRandomRoom.arraySize = 8;*/
        chooseRandomRoom.ChooseRandomRoom();
        GameObject.FindWithTag("Player").transform.position = new Vector3(-10f, -3f, 0f);
        movemap = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player") && movemap == false) 
        {
            active();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&isActive)
        {
            resume();
        }
        if (playerStatus.instance.isMapChange)
        {
            moveMap();
            resume();
            playerStatus.instance.isMapChange = false;
        }
        if (playerStatus.instance.exitPanelOff)
        {
            resume();
            playerStatus.instance.exitPanelOff = false;
        }
    }
}


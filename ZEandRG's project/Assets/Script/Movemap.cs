using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemap : MonoBehaviour
{
    ObjectArrayExample chooseRandomRoom;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            chooseRandomRoom = GameObject.Find("ObjectArrayExample").GetComponent<ObjectArrayExample>();
            chooseRandomRoom.Tag = "Room";
            chooseRandomRoom.arraySize = 8;
            chooseRandomRoom.ChooseRandomRoom();
        }
    }
}

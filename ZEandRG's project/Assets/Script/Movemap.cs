using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemap : MonoBehaviour
{
    [SerializeField] ObjectArrayExample chooseRandomRoom;
    public bool movemap = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player") && movemap == false) 
        {
            movemap = true;
            /*chooseRandomRoom = GameObject.Find("ObjectArrayExample").GetComponent<ObjectArrayExample>();
            chooseRandomRoom.Tag = "Room";
            chooseRandomRoom.arraySize = 8;*/
            chooseRandomRoom.ChooseRandomRoom();
            GameObject.FindWithTag("Player").transform.position = new Vector3(-10f, -3f, 0f);
            movemap = false;
        }
    }
}


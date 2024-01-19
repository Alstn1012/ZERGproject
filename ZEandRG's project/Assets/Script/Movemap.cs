using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemap : MonoBehaviour
{
    private ObjectArrayExample chooseRandomRoom;

    // Start 메서드에서 chooseRandomRoom 초기화
    private void Start()
    {
        chooseRandomRoom = GetComponent<ObjectArrayExample>();
        if (chooseRandomRoom == null)
        {
            Debug.LogError("ObjectArrayExample component not found!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (chooseRandomRoom != null)
            {
                chooseRandomRoom.ChooseRandomRoom();
            }
            else
            {
                Debug.LogError("ObjectArrayExample component not initialized!");
            }
        }
    }
}

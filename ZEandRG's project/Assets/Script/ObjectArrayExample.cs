using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectArrayExample : MonoBehaviour
{
    public string Tag = "Room";
    public int arraySize = 8;

    public List<GameObject> gameObjectsArray;
/*    Movemap destroy;*/
    public GameObject room;
    public GameObject currentRoom;

    public void Start()
    {
/*        destroy = GetComponent<Movemap>();
        destroy.movemap = false;*/
        ChooseRandomRoom();
    }

    public void ChooseRandomRoom()
    {
        if (gameObjectsArray.Count == 0) //매번 반복되는 작업을 처음 1회만 실행되게 변경
        {
            gameObjectsArray = new List<GameObject>();

            // 배열에 태그를 기반으로 게임 오브젝트 할당
            for (int i = 0; i < arraySize; i++)
            {
                string tagName = Tag + (i + 1); // "Room1", "Room2", ..., "Room8" 등의 태그를 하는거에용
                GameObject obj = GameObject.FindGameObjectWithTag(tagName);

                if (obj != null)
                {
                    gameObjectsArray.Add(obj);
                }
                else
                {
                    Debug.LogError("GameObject with tag '" + tagName + "' not found!");
                }
            }
        }

        if (currentRoom != null) //만약 지금 사용중인 방이 있으면 그 방을 삭제함
        {
            gameObjectsArray.Remove(currentRoom);
            Destroy(currentRoom);
            currentRoom = null;
        }
        if(gameObjectsArray.Count > 0) {
            int randomIndex = Random.Range(0, gameObjectsArray.Count);
            gameObjectsArray[randomIndex].transform.position = new Vector2(0, 0);

            currentRoom = gameObjectsArray[randomIndex]; //현재 방으로 초기화
        }
        else
        {
            SceneManager.LoadScene("ClearScene");
        }



/*        if (destroy.movemap == true)
        {
            Destroy(room);
        }*/
    }

}

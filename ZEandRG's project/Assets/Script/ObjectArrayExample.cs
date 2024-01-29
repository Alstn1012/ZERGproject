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
        if (gameObjectsArray.Count == 0) //�Ź� �ݺ��Ǵ� �۾��� ó�� 1ȸ�� ����ǰ� ����
        {
            gameObjectsArray = new List<GameObject>();

            // �迭�� �±׸� ������� ���� ������Ʈ �Ҵ�
            for (int i = 0; i < arraySize; i++)
            {
                string tagName = Tag + (i + 1); // "Room1", "Room2", ..., "Room8" ���� �±׸� �ϴ°ſ���
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

        if (currentRoom != null) //���� ���� ������� ���� ������ �� ���� ������
        {
            gameObjectsArray.Remove(currentRoom);
            Destroy(currentRoom);
            currentRoom = null;
        }
        if(gameObjectsArray.Count > 0) {
            int randomIndex = Random.Range(0, gameObjectsArray.Count);
            gameObjectsArray[randomIndex].transform.position = new Vector2(0, 0);

            currentRoom = gameObjectsArray[randomIndex]; //���� ������ �ʱ�ȭ
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

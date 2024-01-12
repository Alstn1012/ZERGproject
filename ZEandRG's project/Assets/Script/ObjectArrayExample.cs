using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectArrayExample : MonoBehaviour
{
    public string Tag = "Room";
    public int arraySize = 8;

    private GameObject[] gameObjectsArray;

    private void Start()
    {
        gameObjectsArray = new GameObject[arraySize];

        // �迭�� �±׸� ������� ���� ������Ʈ �Ҵ�
        for (int i = 0; i < arraySize; i++)
        {
            string tagName = Tag + (i + 1); // "Room1", "Room2", ..., "Room8" ���� �±׸� �ϴ°ſ���
            GameObject obj = GameObject.FindGameObjectWithTag(tagName);

            if (obj != null)
            {
                gameObjectsArray[i] = obj;
            }
            else
            {
                Debug.LogError("GameObject with tag '" + tagName + "' not found!");
            }
        }

        int randomIndex = Random.Range(0, arraySize);

        gameObjectsArray[randomIndex].transform.position = new Vector2(0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.gameObject.layer = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.layer = 0;
        }
    }
}

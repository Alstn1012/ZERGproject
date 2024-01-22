using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chageLayer : MonoBehaviour
{
    private void passThrough()
    {
        if (playerStatus.instance.whileInvincible == true)
        {
            this.gameObject.layer = 6;
            GameObject.FindWithTag("Player").layer = 3;
        }
        else
        {
            this.gameObject.layer = 0;
            GameObject.FindWithTag("Player").layer = 0;
        }
    }
    void Update()
    {
        passThrough();
    }
}

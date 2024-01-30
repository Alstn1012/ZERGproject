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
        }
        else
        {
            this.gameObject.layer = 7;
        }
    }
    void Update()
    {
        passThrough();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHp : MonoBehaviour
{
    /**private void activedHp(int limit)
    {
        for(int i=0;i<limit; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    private void presentHp(int HP)
    {
        for(int i=0; i<limit; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(132f, 132f, 132f, 180f);
        }
    }**/
    /**private void Hp()
     * {
        for(int i=0; i<6; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            if (i>=6-limit)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                if(limit==hp)
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
                }
                else
                {
                    transform.GetChild(6-limit+(limit-hp)+1).gameObject.GetComponent<Image>().color = new Color(132f, 132f, 132f, 180f);
                }
            }
        }
    }**/
    private void hp()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(132f / 255f, 132f / 255f, 132f / 255f, 180f / 225f);
            if (i >= playerStatus.instance.playerHpLimit - playerStatus.instance.playerHp)
            {
                transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
    void Update()
    {
        hp();
    }
}

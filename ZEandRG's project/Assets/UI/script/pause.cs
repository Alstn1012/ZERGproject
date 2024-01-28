using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class pause : MonoBehaviour
{
    public bool isActive = false;
    public GameObject pausePanel;
    public GameObject background;
    private void active()
    {
        pausePanel.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 0f;
        isActive = true;
        playerStatus.instance.ispanelActive = true;
    }
    private void resume()
    {
        pausePanel.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1.0f;
        isActive = false;
        playerStatus.instance.ispanelActive= false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!playerStatus.instance.ispanelActive&& !isActive)
            {
                active();
            }
            else if(playerStatus.instance.ispanelActive&&isActive)
            {
                resume();
            }
        }
        if (playerStatus.instance.pausePanelOff)
        {
            resume();
            playerStatus.instance.pausePanelOff = false;
        }
    }
}

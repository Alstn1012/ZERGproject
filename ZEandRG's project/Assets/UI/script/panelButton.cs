using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelButton : MonoBehaviour
{
    public void resume()
    {
        playerStatus.instance.pausePanelOff = true;
    }
    public void resume_exit()
    {
        playerStatus.instance.exitPanelOff = true;
    }
    public void title()
    {
        SceneManager.LoadScene("title");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void Enter()
    {
        playerStatus.instance.isMapChange = true;
    }
}

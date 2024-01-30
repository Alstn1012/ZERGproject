using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverSceneButton : MonoBehaviour
{
    public void enter_game()
    {
        SceneManager.LoadScene("title");
    }
    public void exit_game()
    {
        Application.Quit();
    }
}

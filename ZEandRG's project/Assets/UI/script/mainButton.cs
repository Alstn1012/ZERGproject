using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainButton : MonoBehaviour
{
    public void enter_game()
    {
        SceneManager.LoadScene("game");
    }
    public void exit_game()
    {
        Application.Quit();
    }
}

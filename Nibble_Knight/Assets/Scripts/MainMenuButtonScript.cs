using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Game Starting");
        SceneManager.LoadScene("TestPlayfield");
    }

    public void Options()
    {
        Debug.Log("Options Pressed");
        //TODO
    }

    public void Credits()
    {
        Debug.Log("Credits Pressed");
        SceneManager.LoadScene("CreditsScene");
    }

    public void Exit()
    {
        Debug.Log("Exit Pressed");
        Application.Quit();
    }
}

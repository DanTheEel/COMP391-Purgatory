using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("level1");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}

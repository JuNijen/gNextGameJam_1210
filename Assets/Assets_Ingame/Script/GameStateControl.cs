using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControl : MonoBehaviour {

    public void GameQuit()
    {
        Application.Quit();
    }

    public void SaveData()
    {
        //IMSI
    }

    public void GamePause()
    {
        Time.timeScale = 0.0f;
    }
    public void GameResume()
    {
        Time.timeScale = 1.0f;
    }

    public void TouchLog(string logString)
    {
        Debug.Log(logString);
    }
}

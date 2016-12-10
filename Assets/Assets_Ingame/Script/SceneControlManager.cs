using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour
{
    public static SceneControlManager scManager;

    public string sceneName;

    private void Start()
    {
        scManager = GameObject.Find("GameManager")
                   .GetComponent<SceneControlManager>();
    }

    public void SceneChange(string _sceneName)
    {
        _SceneChange(_sceneName);
    }
    private void _SceneChange(string _scneneName)
    {
        SceneManager.LoadScene(_scneneName);
    }
}

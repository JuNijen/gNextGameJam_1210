using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
   

    //현재 움직이고 있는 로봇을 받는다.
    public GameObject selectedObj;

    public void FirstRobot()
    {
        selectedObj.GetComponent<RobotsBehavior>().isActive = true;
    }
    public void RobotChange(GameObject changeObject)
    {
        Debug.Log("GameManager.gameManager.RobotChange(colRe.gameObject);");
        selectedObj.GetComponent<RobotsBehavior>()._RobotChange(changeObject);
    }
    public GameObject GetSelectObject()
    {
        return selectedObj;
    }
}

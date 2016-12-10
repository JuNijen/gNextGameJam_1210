using UnityEngine;
using System.Collections;

public class DoorActionScript : MonoBehaviour {

    public string sceneName;
    //트리거

    /// <summary>
    /// 문을 통과하면 씬전환을 한다.
    /// </summary>
    private void ThoroughDoor()
    {
        //트리거가 트루 일 경우
        if (true)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneControlManager.scManager.SceneChange(sceneName);
            }
        }
    }
}

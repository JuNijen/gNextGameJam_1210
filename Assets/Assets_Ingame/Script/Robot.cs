using UnityEngine;
using System.Collections;

/// <summary>
/// 모든 Robot에 붙이게 될 스크립트.
/// </summary>
public class Robot : MonoBehaviour
{
    public float speed = 3.0f;
    private bool _isActive = true;
    public bool isActive
    {
        get
        {
            return isActive;
        }
        set
        {
            if (value == true)
            {
                //Active된 이미지로 셋팅.
            }
            else
            {
                //Active 해제 시의 애니메이션 실행,
                //DisActive된 상태의 이미지로 셋팅.
            }
        }
    }

    private void Update()
    {
        if (isActive)
        {
            RobotMove();
        }
    }


    private void RobotMove()
    {
        var vexPos = new Vector3
            (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        gameObject.transform.position
            += vexPos * speed * Time.deltaTime;
    }
    private void RobotJump()
    {

    }
    private void RobotAction()
    {

    }
    private void RobotSckill()
    {

    }
}

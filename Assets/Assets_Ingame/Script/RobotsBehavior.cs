using UnityEngine;
using System.Collections;

/// <summary>
/// 모든 Robot에 붙이게 될 스크립트.
/// </summary>
public class RobotsBehavior : MonoBehaviour
{
    GameManager gameManager;

    public float speed = 3.0f;

    private bool _isActive = false;
    public bool isActive
    {
        get
        {
            return _isActive;
        }
        set
        {
            if (value == true)
            {
                //만약, 값이 참이라면 내부 값을 바꿔주고 현재 오브젝트를 넣는다.
                gameManager.selectedObj = gameObject;

                _isActive = true;
                ColorRed();

                //DisActive 해제시의 애니메이션 실행
                //Active된 이미지로 셋팅.
            }
            else
            {
                _isActive = false;
                ColorWhite();

                //Active 해제시의 애니메이션 실행,
                //DisActive된 상태의 이미지로 셋팅.
            }
        }
    }


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    

    private void ColorWhite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;

//        transform.localScale = new Vector3(1.0f, 0.7f, 0.0f);
    }
    private void ColorRed()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

//        transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
    }


    private void Update()
    {
        if (_isActive)
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


    public void _RobotChange(GameObject changeObject)
    {
        Debug.Log("_RobotChange(GameObject changeObject)");
        //값이 들어있는 것이 확인되었다면
        isActive = false;
        changeObject.GetComponent<RobotsBehavior>().isActive = true;
    }
}
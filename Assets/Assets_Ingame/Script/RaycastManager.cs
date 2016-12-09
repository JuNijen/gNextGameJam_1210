using UnityEngine;
using System.Collections;

/// <summary>
/// 전체적인 Raycast를 담당할 스크립트
/// </summary>
public class RaycastManager : MonoBehaviour
{
    //RaycastHit2D 소환에 넣어 줄 벡터.
    private Vector2 mousePosition;
    //Ray의 Hit 값을 받아 올 변수
    private RaycastHit2D rayHit;

    //근처 범위에 있는 도형 리스트
    private Collider2D[] colliderList;
    //찾는 오브젝트와의 거리 제한.
    public float findDistance = 1.0f;



    void Update()
    {
        Raycast2DHit();
    }



    /// <summary>
    /// Overlap로 체크
    /// </summary>
    public void checkOverlap(GameObject gameObject)
    {
        _checkOverlap(gameObject);
    }
    private void _checkOverlap(GameObject gameObject)
    {
        colliderList = Physics2D.OverlapCircleAll
            ((Vector2)gameObject.transform.position, findDistance);

        foreach (Collider2D colRe in colliderList)
            Debug.Log("Re : " + colRe.name);
    }

    /// <summary>
    /// Ray 된 Object를 반환
    /// </summary>
    /// <returns></returns>
    public GameObject GetRayHitObject()
    {
        return rayHit.collider.gameObject;
    }
    /// <summary>
    /// ImsiPos에 마우스 값을 넣어준다.
    /// </summary>
    private void vector2MousePosition()
    {
        mousePosition = new Vector2
            (Camera.main.ScreenToWorldPoint
            (Input.mousePosition).x,
            (Camera.main.ScreenToWorldPoint
            (Input.mousePosition).y)
        );
    }

    /// <summary>
    /// Ray를 쏴서 값을 받아온다.
    /// </summary>
    private void Raycast2DHit()
    {
        vector2MousePosition();

        if (Input.GetMouseButton(0))
        {
            //raycast Hit 2D에 마우스 값을 넣어준다.
            rayHit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //받아온 값이 있을 경우
            if (rayHit)
            {
                Debug.Log(rayHit.collider.name);
                IsChangeBody(rayHit.collider.gameObject);
            }
            else Debug.Log("$$ ERROR :: It is NULL");
        }
    }

    /// <summary>
    /// 추후 로봇을 깨우는 곳에 쓰일 예정이다.
    /// </summary>
    /// <param name="_rayHit"></param>
    private void IsChangeBody(GameObject _rayHit)
    {
        checkOverlap(_rayHit);

        foreach (Collider2D colRe in colliderList) { 
            if (_rayHit == colRe.gameObject)
            {
                //현재로봇.isActive = false;
                //_rayHit.wake();
            }
        }
    }

}

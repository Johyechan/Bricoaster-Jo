using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour, IMovable
{
    public float MoveSpeed { get; set; }
    public float TurnSpeed { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            GoForward();
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            GoBack();
        }

        if(Input.GetKey(KeyCode.A))
        {
            GoLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            GoRight();
        }
    }

    public void GoBack()
    {
        // 뒤로 가는 코드
    }

    public void GoForward()
    {
        // 앞으로 가는 코드
    }

    public void GoLeft()
    {
        // 왼쪽으로 가는 코드
    }

    public void GoRight()
    {
        // 오른쪽으로 가는 코드
    }

    public void Turn()
    {
        // 회전하는 코드
    }
}

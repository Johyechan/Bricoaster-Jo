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
        // �ڷ� ���� �ڵ�
    }

    public void GoForward()
    {
        // ������ ���� �ڵ�
    }

    public void GoLeft()
    {
        // �������� ���� �ڵ�
    }

    public void GoRight()
    {
        // ���������� ���� �ڵ�
    }

    public void Turn()
    {
        // ȸ���ϴ� �ڵ�
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _turnSpeed;

    private Camera mainCam;

    private bool _isMoving;

    private void Start()
    {
        mainCam = Camera.main;
        _isMoving = true;
    }

    private void Update()
    {
        MoveOrTurn();
    }

    // Camera를 움직일 건지 아닌지 판단하는 bool값을 변경시키는 함수
    private void ChangeBool()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(_isMoving);
            _isMoving = ProjectManager.Instance.ChangeBool(_isMoving);
            Debug.Log(_isMoving);
        }
    }

    // 카메라를 움직일 건지 회전 시킬건지 선택하여 실행하게 하는 함수
    private void MoveOrTurn()
    {
        ChangeBool();

        if(_isMoving)
        {
            Move();
        }
        else
        {
            Turn();
        }
    }

    // Camera가 움직이는 함수
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mainCam.transform.position += Vector3.forward * _moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            mainCam.transform.position += Vector3.back * _moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            mainCam.transform.position += Vector3.left * _moveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            mainCam.transform.position += Vector3.right * _moveSpeed;
        }
    }

    // Camera가 회전하는 코드
    private void Turn()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mainCam.transform.Rotate(Vector3.up * _turnSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            mainCam.transform.Rotate(Vector3.down * _turnSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            mainCam.transform.Rotate(Vector3.left * _turnSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            mainCam.transform.Rotate(Vector3.right * _turnSpeed);
        }
    }
}

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

    // Camera�� ������ ���� �ƴ��� �Ǵ��ϴ� bool���� �����Ű�� �Լ�
    private void ChangeBool()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(_isMoving);
            _isMoving = ProjectManager.Instance.ChangeBool(_isMoving);
            Debug.Log(_isMoving);
        }
    }

    // ī�޶� ������ ���� ȸ�� ��ų���� �����Ͽ� �����ϰ� �ϴ� �Լ�
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

    // Camera�� �����̴� �Լ�
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

    // Camera�� ȸ���ϴ� �ڵ�
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

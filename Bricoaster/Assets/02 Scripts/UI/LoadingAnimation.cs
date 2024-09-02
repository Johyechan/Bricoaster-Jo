using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    private float _rotateSpeed;

    private void Start()
    {
        _rotateSpeed = 100f;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -Time.deltaTime * _rotateSpeed));
    }
}

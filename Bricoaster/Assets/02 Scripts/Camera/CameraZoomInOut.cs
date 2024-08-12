using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomInOut : MonoBehaviour
{
    [SerializeField] private float _zoomInOutSpeed;

    private void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        Camera.main.fieldOfView += scrollWheel * Time.deltaTime * _zoomInOutSpeed;
    }
}

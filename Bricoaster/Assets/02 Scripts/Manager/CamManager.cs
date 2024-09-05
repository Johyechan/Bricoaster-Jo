using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamManager : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cm;

    [SerializeField] private Toggle _toggle;

    [SerializeField] private float _changeScreenScaleSpeed;

    private float _minDistanceFromCamera;
    private float _maxDistanceFromCamera;
    private float _curDistanceFromCamera;

    private void Start()
    {
        _toggle.isOn = false;

        _minDistanceFromCamera = _cm.m_Orbits[1].m_Radius;
        _maxDistanceFromCamera = _minDistanceFromCamera + 15f;
        _cm.m_Orbits[1].m_Radius = _maxDistanceFromCamera;
        _curDistanceFromCamera = _cm.m_Orbits[1].m_Radius;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _toggle.isOn = !_toggle.isOn;

        if (!_toggle.isOn)
        {
            _cm.m_YAxis.m_InputAxisName = "";
            _cm.m_XAxis.m_InputAxisName = "";
            _cm.m_XAxis.m_InputAxisValue = 0f;
            _cm.m_YAxis.m_InputAxisValue = 0f;
        }
        else
        {
            _cm.m_YAxis.m_InputAxisName = "Mouse Y";
            _cm.m_XAxis.m_InputAxisName = "Mouse X";
        }

        ZoomInOut();
    }

    private void ZoomInOut()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0.0f)
        {
            float newFieldOfView = _cm.m_Orbits[1].m_Radius + scrollInput * _changeScreenScaleSpeed;
            _curDistanceFromCamera = newFieldOfView;
            _curDistanceFromCamera = Mathf.Clamp(_curDistanceFromCamera, _minDistanceFromCamera, _maxDistanceFromCamera);
            _cm.m_Orbits[1].m_Radius = Mathf.Clamp(_curDistanceFromCamera, _minDistanceFromCamera, _maxDistanceFromCamera);
        }

        if (Input.touchCount >= 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            _cm.m_Orbits[1].m_Radius += deltaMagnitudeDiff * (_changeScreenScaleSpeed / 10);
            _curDistanceFromCamera += deltaMagnitudeDiff * (_changeScreenScaleSpeed / 10);

            _curDistanceFromCamera = Mathf.Clamp(_curDistanceFromCamera, _minDistanceFromCamera, _maxDistanceFromCamera);
            _cm.m_Orbits[1].m_Radius = Mathf.Clamp(_cm.m_Orbits[1].m_Radius, _minDistanceFromCamera, _maxDistanceFromCamera);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour, ISnappingable, IPositionCalculator
{
    public Vector3 PositionCalculator(Vector3 positionToChange)
    {
        float x = positionToChange.x;
        float y = positionToChange.y;
        float z = positionToChange.z;

        x = FindCloseMultiple(x);
        z = FindCloseMultiple(z);

        positionToChange = new Vector3(x, y, z);

        return positionToChange;
    }

    private float FindCloseMultiple(float value)
    {
        if(value % 0.5f != 0)
        {
            // value를 0.5로 나누었을 때 나오는 나머지 값을 구하고 그 나머지 값이 0.5에 가까운지 1에 가까운지 판단한다
            // 1에 가까울 경우 그냥 반올림을 한다
            // 0.5에 가까울 경우 4.35 이럴 경우일테니 그냥 4.5로 바꾼다
            float remainder = value % 0.5f;
            return Mathf.Round(value);
        }

        return value;
    }

    public void Snapping(Collider otherCollider)
    {
        float x = transform.position.x;
        float y = otherCollider.gameObject.transform.position.y;
        float z = transform.position.z;

        transform.position = PositionCalculator(new Vector3(x, y, z));
    }

    private void OnTriggerStay(Collider other)
    {
        Snapping(other);
    }
}

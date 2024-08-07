using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 첫 번째 - 밑 판에 튀어나온 부분의 사이 거리는 0.5 이다
// 두 번째 - x,z 축 모두 사이 거리가 같다
// 세 번째 - y축은 밑 판의 y축과 동일하게 하면된다
// 가설 1 - 그럼 x축과 z축을 구하고 그 구한 값이 0.5의 배수 중에서 가장 근접한 위치로 움직이게 하면 되지 않을까? 된건가?

public class Block : MonoBehaviour, ISnappingable, IPositionCalculator
{
    public Vector3 PositionCalculator(Vector3 positionToChange)
    {
        float x = positionToChange.x;
        float y = positionToChange.y;
        float z = positionToChange.z;

        Debug.Log(new Vector3(x, y, z));

        x = FindCloseMultiple(x);
        z = FindCloseMultiple(z);

        positionToChange = new Vector3(x, y, z);

        Debug.Log(positionToChange);

        return positionToChange;
    }

    private float FindCloseMultiple(float value)
    {
        if(value % 0.5f != 0)
        {
            return Mathf.Round(value);
        }

        return value;
    }

    public void Snapping(Collider otherCollider)
    {
        float x = transform.position.x;
        float y = otherCollider.gameObject.transform.position.y;
        float z = transform.position.z;

        Debug.Log(new Vector3(x, y, z));
        transform.position = PositionCalculator(new Vector3(x, y, z));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Snapping(other);
    }
}

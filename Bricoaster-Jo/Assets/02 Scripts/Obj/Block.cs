using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ù ��° - �� �ǿ� Ƣ��� �κ��� ���� �Ÿ��� 0.5 �̴�
// �� ��° - x,z �� ��� ���� �Ÿ��� ����
// �� ��° - y���� �� ���� y��� �����ϰ� �ϸ�ȴ�
// ���� 1 - �׷� x��� z���� ���ϰ� �� ���� ���� 0.5�� ��� �߿��� ���� ������ ��ġ�� �����̰� �ϸ� ���� ������? �Ȱǰ�?

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

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
            // value�� 0.5�� �������� �� ������ ������ ���� ���ϰ� �� ������ ���� 0.5�� ������� 1�� ������� �Ǵ��Ѵ�
            // 1�� ����� ��� �׳� �ݿø��� �Ѵ�
            // 0.5�� ����� ��� 4.35 �̷� ������״� �׳� 4.5�� �ٲ۴�
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

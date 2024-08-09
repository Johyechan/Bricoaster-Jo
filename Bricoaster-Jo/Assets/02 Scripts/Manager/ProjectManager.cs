using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoBehaviour
{
    public static ProjectManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �� �Լ��� bool���� ������ �׳� ���� ���� �ݴ�� �ٲ㼭 ��ȯ�ϴ� �Լ�
    public bool ChangeBool(bool value)
    {
        return !value;
    }
}

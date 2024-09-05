using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

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

    // ��ȣ�ȿ� �ִ� ���ڴ� �����ϴ� �Լ�
    public string NameChange(string str)
    {
        return Regex.Replace(str, @"\s?\(.*?\)", "");
    }

    // �̸��� ������ enum���� �̸��� ������ Ȯ���ϰ� �� enum���� ã�� �Լ�
    public ObjectPoolType FindType(string name)
    {
        bool finded;
        foreach (ObjectPoolType type in Enum.GetValues(typeof(ObjectPoolType)))
        {
            finded = type.ToString().Equals(name, StringComparison.OrdinalIgnoreCase);
            if (finded)
            {
                return type;
            }
        }

        return ObjectPoolType.None;
    }

    public Vector3 CalculateCenterPos(JsonBase jsonBase)
    {
        Vector3 centerPos = Vector3.zero;
        int trackCount = jsonBase.trackData.Length;

        foreach(TrackData data in jsonBase.trackData)
        {
            centerPos += data.position;
        }

        centerPos /= trackCount;

        return centerPos;
    }
}

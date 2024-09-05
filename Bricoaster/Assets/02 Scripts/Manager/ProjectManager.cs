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

    // 이 함수에 bool값을 넣으면 그냥 들어온 값을 반대로 바꿔서 반환하는 함수
    public bool ChangeBool(bool value)
    {
        return !value;
    }

    // 괄호안에 있는 문자는 삭제하는 함수
    public string NameChange(string str)
    {
        return Regex.Replace(str, @"\s?\(.*?\)", "");
    }

    // 이름을 가지고 enum값과 이름이 같은지 확인하고 그 enum값을 찾는 함수
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

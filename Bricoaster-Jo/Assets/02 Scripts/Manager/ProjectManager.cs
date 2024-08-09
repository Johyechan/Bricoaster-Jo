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

    // 이 함수에 bool값을 넣으면 그냥 들어온 값을 반대로 바꿔서 반환하는 함수
    public bool ChangeBool(bool value)
    {
        return !value;
    }
}

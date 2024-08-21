using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScene : MonoBehaviour
{
    public string SceneName
    {
        get
        {
            return _sceneName;
        }

        set
        {
            _sceneName = value;
        }
    }

    private string _sceneName;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

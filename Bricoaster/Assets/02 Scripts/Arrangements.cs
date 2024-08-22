using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrangements : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public List<Object> Prefabs
    {
        get
        {
            return _prefabs;
        }
    }
    private List<Object> _prefabs = new List<Object>();

    public List<Object> Jsons
    {
        get
        {
            return _jsons;
        }
    }
    private List<Object> _jsons = new List<Object>();

    public List<Object> Textures
    {
        get
        {
            return _textures;
        }
    }
    private List<Object> _textures = new List<Object>();
}

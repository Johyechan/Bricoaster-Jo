using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrangements : MonoBehaviour
{
    public List<GameObject> Prefabs
    {
        get
        {
            return _prefabs;
        }
    }
    private List<GameObject> _prefabs;

    public List<TextAsset> Jsons
    {
        get
        {
            return _jsons;
        }
    }
    private List<TextAsset> _jsons;
}

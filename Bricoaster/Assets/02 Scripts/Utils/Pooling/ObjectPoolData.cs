using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ObjectPoolData
{
    public GameObject prefab;
    public ObjectPoolType type;
    public int prefabCount;
}

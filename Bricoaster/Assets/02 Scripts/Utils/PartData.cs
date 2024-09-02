using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackData
{
    public string name;
    public Vector3 position;
    public Vector3 rotation;
    public Color color;
    public bool isPlaced;
    public bool isReversed;
    public int connectedStartJointIdx;
    public int connectedEndJointIdx;
    public int connectType;
}

[System.Serializable]
public class JsonBase
{
    public TrackData[] trackData;
}
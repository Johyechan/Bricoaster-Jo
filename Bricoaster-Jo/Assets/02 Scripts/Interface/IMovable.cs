using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public float MoveSpeed
    {
        get;
        set;
    }

    public float TurnSpeed
    {
        get;
        set;
    }

    public void GoForward();
    public void GoBack();
    public void GoRight();
    public void GoLeft();
    public void Turn();
}

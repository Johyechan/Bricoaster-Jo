using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBase : MonoBehaviour, IQuit, IChangeScene
{
    protected IChangeScene _changeHandler;

    protected IQuit _quitHandler;

    protected virtual void Start() 
    {
        _changeHandler = GetComponent<IChangeScene>();
        _quitHandler = GetComponent<IQuit>();
    }

    protected virtual void Update() { }

    public virtual void IsClicked() { }
}

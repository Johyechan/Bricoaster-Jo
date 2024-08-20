using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneChangeButton : ButtonBase
{
    [SerializeField] private string _sceneName;

    public override void IsClicked()
    {
        base.IsClicked();

        _changeHandler.ChangeScene(_sceneName);
    }
}

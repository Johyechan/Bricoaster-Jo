using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneChangeButton : ButtonBase
{
    [SerializeField] private string _sceneName;

    public override void IsClicked()
    {
        base.IsClicked();
        
        KeepScene keep = GameObject.Find("KeepScene").GetComponent<KeepScene>();
        keep.SceneName = _sceneName;

        _changeHandler.ChangeScene("Loading");
    }
}

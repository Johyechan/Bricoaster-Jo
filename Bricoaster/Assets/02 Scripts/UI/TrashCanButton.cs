using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanButton : ButtonBase
{
    [SerializeField] Transform _makeTrans;

    [SerializeField] GuideManager _guideManager;

    private ButtonFunctionAdder _adder;

    private int _cnt;

    protected override void Start()
    {
        _adder = GameObject.Find("ButtonLoader").GetComponent<ButtonFunctionAdder>();
    }

    public override void IsClicked()
    {
        if(!_adder.IsMaking)
        {
            _guideManager.IsReset = true;
            _cnt = _makeTrans.childCount;
            for (int i = _cnt - 1; i >= 0; i--)
            {
                GameObject returnObj = _makeTrans.GetChild(i).gameObject;
                ObjectPoolType type = ProjectManager.Instance.FindType(ProjectManager.Instance.NameChange(returnObj.name));
                ObjectPool.Instance.ReturnObject(type, returnObj);
            }
        }
    }
}

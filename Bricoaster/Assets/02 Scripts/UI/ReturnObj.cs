using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObj : MonoBehaviour
{
    [SerializeField] private Transform _makeTrans;

    public void ReturnAll()
    {
        if(_makeTrans.childCount > 0)
        {
            for(int i = 0; i< _makeTrans.childCount; i++)
            {
                GameObject obj = _makeTrans.GetChild(i).gameObject;
                ObjectPoolType type = ProjectManager.Instance.FindType(ProjectManager.Instance.NameChange(obj.name));
                ObjectPool.Instance.ReturnObject(type, obj);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolFiller : MonoBehaviour
{
    private Arrangements _arr;
    private bool _isNew;

    void Start()
    {
        _arr = GameObject.Find("Arrangements").GetComponent<Arrangements>();
    }

    public void FillObjectPool()
    {
        _isNew = true;
        foreach(var obj in _arr.Prefabs)
        {
            ObjectPoolData newObjectPoolData = new ObjectPoolData();

            GameObject gameObject = obj as GameObject;
            foreach(ObjectPoolData opd in ObjectPool.Instance.PoolDatas)
            {
                if(opd.prefab == gameObject)
                {
                    _isNew = false;
                    break;
                }
            }

            if(_isNew)
            {
                if (gameObject != null)
                {
                    newObjectPoolData.prefab = gameObject;
                }
                newObjectPoolData.type = ProjectManager.Instance.FindType(ProjectManager.Instance.NameChange(gameObject.name));
                newObjectPoolData.prefabCount = 10;
                ObjectPool.Instance.PoolDatas.Add(newObjectPoolData);
            }
            
        }

        if(_isNew)
        {
            ObjectPool.Instance.callInit?.Invoke();
        }
    }
}

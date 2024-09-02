using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public List<ObjectPoolData> PoolDatas
    {
        get
        {
            return _poolDatas;
        }
    }

    private List<ObjectPoolData> _poolDatas = new List<ObjectPoolData>();

    private Dictionary<ObjectPoolType, ObjectPoolData> _objectPoolDataMap = new Dictionary<ObjectPoolType, ObjectPoolData>();
    private Dictionary<ObjectPoolType, Queue<GameObject>> _pool = new Dictionary<ObjectPoolType, Queue<GameObject>>();

    public Action callInit;

    public bool End
    {
        get
        {
            return _end;
        }
    }
    private bool _end;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        callInit += Init;
    }

    private void Init()
    {
        foreach(var data in _poolDatas)
        {
            _objectPoolDataMap.Add(data.type, data);
        }

        foreach(var poolData in _objectPoolDataMap)
        {
            _pool.Add(poolData.Key, new Queue<GameObject>());
            var objecPoolData = poolData.Value;

            for(int i = 0; i < objecPoolData.prefabCount; i++)
            {
                var poolObject = CreateNewObject(poolData.Key);
                _pool[poolData.Key].Enqueue(poolObject);
            }
        }

        _end = true;
    }

    private GameObject CreateNewObject(ObjectPoolType type)
    {
        var newObj = Instantiate(_objectPoolDataMap[type].prefab, transform);
        newObj.SetActive(false);

        return newObj;
    }

    public GameObject GetObject(ObjectPoolType type, Transform trans = null)
    {
        if(_pool[type].Count > 0)
        {
            var obj = _pool[type].Dequeue();
            obj.transform.SetParent(trans);
            obj.SetActive(true);
            return obj;
        }
        else
        {
            var obj = CreateNewObject(type);
            obj.transform.SetParent(trans);
            obj.SetActive(true);
            return obj;
        }
    }

    public void ReturnObject(ObjectPoolType type, GameObject obj, bool isButton = false)
    {
        obj.SetActive(false);
        if(isButton)
        {
            obj.name = "Button";
            Image image = obj.transform.GetChild(0).GetComponent<Image>();
            TMP_Text tmp = obj.transform.GetChild(1).GetComponent<TMP_Text>();
            tmp.text = "";
            image.sprite = null;
            obj.transform.GetChild(0).gameObject.SetActive(false);
        }
        obj.transform.SetParent(this.transform);
        _pool[type].Enqueue(obj);
    }
}

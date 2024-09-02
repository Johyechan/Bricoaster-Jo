using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctionAdder : MonoBehaviour
{
    [SerializeField] private bool _isPartButton;

    [SerializeField] private Transform _makeTrans;

    private Arrangements _arr;

    public bool IsMaking
    {
        get
        {
            return _isMaking;
        }
    }
    private bool _isMaking;

    void Start()
    {
        _arr = GameObject.Find("Arrangements").GetComponent<Arrangements>();
        _isMaking = false;
    }

    public void AddFunctionToButton(GameObject obj)
    {
        Button button = obj.GetComponent<Button>();

        if(_isPartButton)
        {
            button.onClick.AddListener(() => OnPartButtonClick(obj));
        }
        else
        {
            button.onClick.AddListener(() => OnGuideButtonClick(obj));
        }
    }

    private void OnGuideButtonClick(GameObject obj)
    {
        if (CheckIsEmpty())
        {
            MakeTrack(obj);
        }
    }

    private void MakeTrack(GameObject obj)
    {
        _isMaking = true;
        foreach (Object value in _arr.Jsons)
        {
            TextAsset textAsset = value as TextAsset;

            if (obj.name == textAsset.name)
            {
                JsonBase jsonBase = JsonUtility.FromJson<JsonBase>(textAsset.text);
                StartCoroutine(MakeTrackCo(jsonBase));
                break;
            }

        }
    }

    // 위치가 이상한거 잡아줘야 하고
    // 카메라가 중심 위치를 봐야한다
    private IEnumerator MakeTrackCo(JsonBase jsonBase)
    {
        foreach (TrackData data in jsonBase.trackData)
        {
            GameObject track = ObjectPool.Instance.GetObject(ProjectManager.Instance.FindType(data.name), _makeTrans);
            yield return new WaitForSeconds(0.2f);
            track.transform.position = data.position;
            track.transform.rotation = Quaternion.Euler(data.rotation);
            ChangeColor(track, data.color);
        }

        _isMaking = false;
    }

    private void ChangeColor(GameObject obj, Color color)
    {
        Transform[] children = obj.transform.GetComponentsInChildren<Transform>();

        foreach(Transform trans in children)
        {
            if (trans == transform)
            {
                continue;
            }

            Renderer renderer = trans.GetComponent<Renderer>();
            if(renderer != null && renderer.material != null)
            {
                renderer.material.color = color;
                break;
            }
        }
    }

    private void OnPartButtonClick(GameObject obj)
    {
        ObjectPoolType type = ProjectManager.Instance.FindType(obj.name);
        if(CheckIsEmpty())
        {
            StartCoroutine(MakeObj(type));
        }
        else
        {
            if(CheckIsOther(obj.name))
            {
                ReturnObj();

                StartCoroutine(MakeObj(type));
            }
            else
            {
                ReturnObj();
            }
        }
    }

    private void ReturnObj()
    {
        GameObject otherObj = _makeTrans.GetChild(0).gameObject;
        string str = ProjectManager.Instance.NameChange(otherObj.name);
        ObjectPoolType poolType = ProjectManager.Instance.FindType(str);
        ObjectPool.Instance.ReturnObject(poolType, otherObj);
    }

    private IEnumerator MakeObj(ObjectPoolType type)
    {
        GameObject gameObj = ObjectPool.Instance.GetObject(type, _makeTrans);
        yield return new WaitForSeconds(0.2f);
        gameObj.transform.localPosition = Vector3.zero;
        gameObj.transform.rotation = Quaternion.identity;
    }

    private bool CheckIsEmpty()
    {
        if(_makeTrans.childCount > 0)
        {
            return false;
        }

        return true;
    }

    private bool CheckIsOther(string name)
    {
        if(ProjectManager.Instance.NameChange(_makeTrans.GetChild(0).gameObject.name) == name)
        {
            return false;
        }

        return true;
    }
}

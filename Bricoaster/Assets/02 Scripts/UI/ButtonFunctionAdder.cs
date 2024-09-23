using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctionAdder : MonoBehaviour
{
    [SerializeField] private bool _isPartButton;

    [SerializeField] private Transform _makeTrans;

    [SerializeField] private CamManager _camMgr;

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

    private IEnumerator MakeTrackCo(JsonBase jsonBase)
    {
        Vector3 plusPos = ProjectManager.Instance.CalculateCenterPos(jsonBase);
        foreach (TrackData data in jsonBase.trackData)
        {
            GameObject track = ObjectPool.Instance.GetObject(ProjectManager.Instance.FindType(data.name), _makeTrans);
            yield return new WaitForSeconds(0.2f);
            //_camMgr.CamPointOfView(track.transform);
            track.transform.position = data.position - plusPos;
            if (ProjectManager.Instance.NameChange(track.name) == "Lego_2x1" && Mathf.Abs(data.rotation.y) == 90)
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            }
            else
            {
                track.transform.rotation = Quaternion.Euler(data.rotation);
            }
            yield return new WaitUntil(() => ChangeColor(track, data.color));
            Debug.Log("dd");
            // 가끔 안나오는 버그 뭐임?
            // 그리고 그림자 지는거 없애는 방법을 찾자
        }

        _isMaking = false;
    }

    private bool ChangeColor(GameObject obj, Color color)
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
                return true;
            }
        }

        return false;
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
        if(gameObj.tag == "Rail")
        {
            ChangePosForPartsSceneOnly(gameObj.transform);
        }
        else if(gameObj.tag == "Plan")
        {
            gameObj.transform.position = new Vector3(12.5f, 0, 12.5f);
        }
        else
        {
            gameObj.transform.position = Vector3.zero;
        }
        gameObj.transform.rotation = Quaternion.identity;
    }

    private void ChangePosForPartsSceneOnly(Transform trans)
    {
        Transform[] transforms = trans.GetComponentsInChildren<Transform>();

        foreach(Transform t in transforms)
        {
            if(t.name == "PartsScenePos")
            {
                trans.position = t.localPosition;
                break;
            }
        }
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

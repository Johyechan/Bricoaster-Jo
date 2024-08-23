using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctionAdder : MonoBehaviour
{
    [SerializeField] private bool _isPartButton;

    [SerializeField] private Transform _makeTrans;
    public void AddFunctionToButton(GameObject obj)
    {
        Button button = obj.GetComponent<Button>();

        if(_isPartButton)
        {
            button.onClick.AddListener(() => OnPartButtonClick(obj));
        }
        else
        {
            //button.onClick.AddListener();
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
        gameObj.transform.position = Vector3.zero;
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

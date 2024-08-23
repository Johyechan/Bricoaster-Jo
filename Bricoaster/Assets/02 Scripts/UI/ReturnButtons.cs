using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtons : MonoBehaviour
{
    [SerializeField] private GameObject _buttons;

    public void ReturnAll()
    {
        for (int i = 0; i < _buttons.transform.childCount; i++)
        {
            GameObject button = _buttons.transform.GetChild(i).gameObject;
            ObjectPoolType type = ProjectManager.Instance.FindType(ProjectManager.Instance.NameChange(button.name));
            ObjectPool.Instance.ReturnObject(type, button);
        }
    }
}

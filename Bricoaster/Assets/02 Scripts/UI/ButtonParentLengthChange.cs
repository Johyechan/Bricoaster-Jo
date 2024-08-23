using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonParentLengthChange : MonoBehaviour
{
    [SerializeField] private RectTransform _buttonParent;

    void Update()
    {
        Vector2 currentSize = _buttonParent.sizeDelta;

        _buttonParent.sizeDelta = new Vector2(_buttonParent.transform.childCount * 200, currentSize.y);
    }
}

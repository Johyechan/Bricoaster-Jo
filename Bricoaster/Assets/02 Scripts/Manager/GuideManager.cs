using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _curTmpText;
    [SerializeField] private TMP_Text _maxTmpText;

    [SerializeField] private Transform _makeTrans;

    public bool IsCanChangeOrder
    {
        get
        {
            return _isCanChangeOrder;
        }

        set
        {
            _isCanChangeOrder = value;
        }
    }
    private bool _isCanChangeOrder;

    public bool IsReset
    {
        get
        {
            return _isReset;
        }

        set
        {
            _isReset = value;
        }
    }
    private bool _isReset;

    // Start is called before the first frame update
    void Start()
    {
        _maxTmpText.text = "-";
        _curTmpText.text = _maxTmpText.text;
        _isReset = true;
        _isCanChangeOrder = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isReset)
        {
            _maxTmpText.text = "-";
            _curTmpText.text = _maxTmpText.text;
            _isReset = false;
        }

        if(_isCanChangeOrder)
        {
            _maxTmpText.text = _makeTrans.childCount.ToString();
            _curTmpText.text = _maxTmpText.text;
            _isCanChangeOrder = false;
        }
    }
}

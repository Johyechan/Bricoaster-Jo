using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideOrderButton : ButtonBase
{
    [SerializeField] private TMP_Text _currentOrderNumText;
    [SerializeField] private TMP_Text _maxOrderNumText;

    [SerializeField] private Transform _makeTrans;

    [SerializeField] private bool _isLeft;

    public override void IsClicked()
    {
        base.IsClicked();
        if(_currentOrderNumText.text != "-" && _maxOrderNumText.text != "-")
        {
            int curOrderNum = int.Parse(_currentOrderNumText.text);
            int maxOrderNum = int.Parse(_maxOrderNumText.text);

            if (_isLeft && curOrderNum > 0)
            {
                curOrderNum -= 1;
            }
            else if(!_isLeft && curOrderNum < maxOrderNum)
            {
                curOrderNum += 1;
            }

            for (int i = _makeTrans.childCount - 1;  i >= curOrderNum; i--)
            {
                _makeTrans.GetChild(i).gameObject.SetActive(false);
            }
            for(int i = 0; i < curOrderNum; i++)
            {
                _makeTrans.GetChild(i).gameObject.SetActive(true);
            }

            int count = 0;
            for (int i = _makeTrans.childCount - 1; i >= 0; i--)
            {
                if (_makeTrans.GetChild(i).gameObject.activeSelf != false)
                {
                    count++;
                }
            }

            _currentOrderNumText.text = count.ToString();
        }
    }
}

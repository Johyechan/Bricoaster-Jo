using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffButton : ButtonBase
{
    [SerializeField] GameObject _onOffObj;
    [SerializeField] bool _isOneButton;
    [SerializeField] bool _isOnButton;

    public override void IsClicked()
    {
        base.IsClicked();
        
        if(!_isOneButton)
        {
            if (_isOnButton)
            {
                _onOffObj.SetActive(true);
            }
            else
            {
                _onOffObj.SetActive(false);
            }
        }
        else
        {
            if(_onOffObj.activeSelf)
            {
                _onOffObj.SetActive(false);
            }
            else
            {
                _onOffObj.SetActive(true);
            }
        }

    }
}

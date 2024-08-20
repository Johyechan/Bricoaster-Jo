using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : ButtonBase
{
    public override void IsClicked()
    {
        base.IsClicked();

        _quitHandler.Quit();
    }
}

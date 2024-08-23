using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrefabButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _tmp;

    private void OnDisable()
    {
        gameObject.name = "Button";
        _image.sprite = null;
        _image.gameObject.SetActive(false);
        _tmp.text = "";
    }
}

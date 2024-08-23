using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoad : MonoBehaviour
{
    [SerializeField] private Transform _buttonsPanelTrans;

    private Arrangements _arr;
    private ButtonFunctionAdder _adder;

    [SerializeField] private bool _useImage;

    void Start()
    {
        _arr = GameObject.Find("Arrangements").GetComponent<Arrangements>();
        _adder = GetComponent<ButtonFunctionAdder>();
        MakeButtons();
    }
    
    private void MakeButtons()
    {
        if (_useImage)
        {
            foreach (Object value in _arr.Textures)
            {
                GameObject button = ObjectPool.Instance.GetObject(ObjectPoolType.Button, _buttonsPanelTrans);
                button.name = ProjectManager.Instance.NameChange(value.name);
                UseImage(button, value);
                _adder.AddFunctionToButton(button);
            }
        }
        else
        {
            // 텍스트 버전
        }
    }

    private void UseImage(GameObject button, Object value)
    {
        button.transform.GetChild(0).gameObject.SetActive(true);
        Image image = button.transform.GetChild(0).GetComponent<Image>();
        Texture2D texture2D = value as Texture2D;
        Sprite newSprite = TextureToSprite(texture2D);
        image.sprite = newSprite;
    }

    private Sprite TextureToSprite(Texture2D texture)
    {
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return newSprite;
    }
}

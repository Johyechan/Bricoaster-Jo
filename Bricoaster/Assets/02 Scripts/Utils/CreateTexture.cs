using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateTexture : MonoBehaviour
{
    [SerializeField] private Camera _captureCam;
    [SerializeField] private string _savePath;
    [SerializeField] private string _fileName;

    void Start()
    {
#if UNITY_EDITOR
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _captureCam.targetTexture = renderTexture;
        _captureCam.Render();

        RenderTexture.active = renderTexture;
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        _captureCam.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        byte[] bytes = texture2D.EncodeToPNG();
        string fullPath = _savePath + _fileName + ".png";
        System.IO.File.WriteAllBytes(fullPath, bytes);


        UnityEditor.AssetDatabase.Refresh();

        Sprite newSprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(fullPath);
#endif
    }
}

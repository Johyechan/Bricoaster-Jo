using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSprite : MonoBehaviour
{
    [SerializeField] private Camera _captureCam;
    [SerializeField] private string _savePath;
    [SerializeField] private string _fileName;

    void Start()
    {
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
        string fullPath = _savePath + _fileName;
        System.IO.File.WriteAllBytes(fullPath, bytes);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif

        Sprite newSprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(fullPath);
    }
}

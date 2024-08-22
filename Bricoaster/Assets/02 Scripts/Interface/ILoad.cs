using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public interface ILoad
{
    public void LoadAssets<T>(string label) where T : Object
    {
        Addressables.LoadAssetsAsync<T>(label, OnAssetLoaded).Completed += OnLoadCompleted;
    }

    private void OnAssetLoaded<T>(T asset) where T : Object
    {
        // 여길 뭘로 채울것인가
        Debug.Log(asset);
    }

    public void OnLoadCompleted<T>(AsyncOperationHandle<IList<T>> handle) where T : Object;
}

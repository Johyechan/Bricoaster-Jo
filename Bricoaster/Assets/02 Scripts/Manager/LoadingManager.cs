using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour, ILoad
{
    [SerializeField] private string _prefabsGroupName;
    [SerializeField] private string _jsonsGroupName;

    private ILoad _loadHandle;
    private bool _end;
    private Arrangements _arr;

    void Start()
    {
        _loadHandle = GetComponent<ILoad>();
        _end = false;
        _arr = GameObject.Find("Arrangements").GetComponent<Arrangements>();
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        KeepScene keep = GameObject.Find("KeepScene").GetComponent<KeepScene>();
        if (keep.SceneName == "Guides")
        {
            _loadHandle.LoadAssets<GameObject>(_prefabsGroupName);
            yield return new WaitUntil(() => _end == true);
            _end = false;
            _loadHandle.LoadAssets<TextAsset>(_jsonsGroupName);
        }
        else
        {
            _loadHandle.LoadAssets<GameObject>(_prefabsGroupName);
        }
        yield return new WaitUntil(() => _end == true);
        SceneManager.LoadScene(keep.SceneName);
    }

    public void OnLoadCompleted<T>(AsyncOperationHandle<IList<T>> handle) where T : Object
    {
        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var asset in handle.Result)
            {
                if(asset.GetType() == typeof(GameObject))
                {
                    if (_arr.Prefabs.Count > 0)
                    {
                        if (!_arr.Prefabs.Contains(asset))
                        {
                            _arr.Prefabs.Add(asset);
                        }
                    }
                }
                else if(asset.GetType() == typeof(TextAsset))
                {
                    if(_arr.Jsons.Count > 0)
                    {
                        if (!_arr.Jsons.Contains(asset))
                        {
                            _arr.Jsons.Add(asset);
                        }
                    }
                }
            }

            _end = true;
        }
    }
}

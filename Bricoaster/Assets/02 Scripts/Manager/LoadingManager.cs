using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

// 이제 오브젝트 풀 만들고 버튼 생성해주는 것만 해줘
public class LoadingManager : MonoBehaviour, ILoad
{
    [SerializeField] private string _prefabsGroupName;
    [SerializeField] private string _jsonsGroupName;
    [SerializeField] private string _texturesGroupName;

    private ILoad _loadHandle;
    private bool _end;
    private Arrangements _arr;
    private PoolFiller _filler;

    void Start()
    {
        _loadHandle = GetComponent<ILoad>();
        _end = false;
        _arr = GameObject.Find("Arrangements").GetComponent<Arrangements>();
        _filler = GetComponent<PoolFiller>();
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
            yield return new WaitUntil(() => _end == true);

            _end = false;
            _loadHandle.LoadAssets<TextAsset>(_jsonsGroupName);
            yield return new WaitUntil(() => _end == true);

            _end = false;
            _loadHandle.LoadAssets<Texture2D>(_texturesGroupName);
        }
        yield return new WaitUntil(() => _end == true);
        _filler.FillObjectPool();
        yield return new WaitUntil(() => ObjectPool.Instance.End == true);
        SceneManager.LoadScene(keep.SceneName);
    }

    private void OkToAdd(Object value, List<Object> list)
    {
        if(list.Count > 0)
        {
            if(!list.Contains(value))
            {
                list.Add(value);
            }
        }
        else
        {
            list.Add(value);
        }
    }

    public void OnLoadCompleted<T>(AsyncOperationHandle<IList<T>> handle) where T : Object
    {
        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var asset in handle.Result)
            {
                if(asset.GetType() == typeof(GameObject))
                {
                    OkToAdd(asset, _arr.Prefabs);
                }
                else if(asset.GetType() == typeof(TextAsset))
                {
                    OkToAdd(asset, _arr.Jsons);
                }
                else if(asset.GetType() == typeof(Texture2D))
                {
                    OkToAdd(asset, _arr.Textures);
                }
            }

            _end = true;
        }
    }
}

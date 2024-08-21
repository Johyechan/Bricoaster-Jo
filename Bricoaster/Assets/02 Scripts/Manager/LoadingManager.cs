using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        // 여기 이제 Addressable로 데이터를 다 로드 하면 넘어가게 ㄱㄱ
        // 내일 위에 있는 거 하고 빌드되는 모습 Giude에서 보이게 하기
        yield return null;
        KeepScene keep = GameObject.Find("KeepScene").GetComponent<KeepScene>();
        SceneManager.LoadScene(keep.SceneName);
    }
}

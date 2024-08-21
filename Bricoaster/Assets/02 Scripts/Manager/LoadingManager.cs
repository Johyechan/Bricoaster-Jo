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
        // ���� ���� Addressable�� �����͸� �� �ε� �ϸ� �Ѿ�� ����
        // ���� ���� �ִ� �� �ϰ� ����Ǵ� ��� Giude���� ���̰� �ϱ�
        yield return null;
        KeepScene keep = GameObject.Find("KeepScene").GetComponent<KeepScene>();
        SceneManager.LoadScene(keep.SceneName);
    }
}

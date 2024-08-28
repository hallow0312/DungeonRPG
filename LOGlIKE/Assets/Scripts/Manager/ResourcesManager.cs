using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager :SingleTon<ResourcesManager>
{
    public T Load<T>(string path) where T : MonoBehaviour
    {
        return Resources.Load<T>(path);
        //는 Unity 프로젝트 내의 특정 경로에 있는 리소스를 로드하고
        // 그 리소스가 MonoBehaviour를 상속하는 타입이라면 그 타입으로 반환해줌.
    }
    public GameObject Create(string  path, Transform parent =null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if(prefab == null)
        {
            Debug.Log("Failed to Load Prefab");
            return null;
        }
        Instantiate(prefab, parent);
        return prefab;
    }
    public void Release (GameObject prefab)
    {
        if(prefab==null)
        {
            return;
        }
        Destroy(prefab);
    }
}

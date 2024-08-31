using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : SingleTon<ResourcesManager>
{
    public T Load<T>(string path) where T : Object // object : 시스템 오브젝트 
    {
        return Resources.Load<T>(path);
    }

    public GameObject Create(string path, Transform parent = null) //default 매개변수 
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.Log("Failed to Load Prefab");
            return null;
        }
        Instantiate(prefab, parent);
        return prefab;
    }
    public void Release(GameObject prefab)
    {
        if (prefab == null)
        {
            return;
        }

        Destroy(prefab);
    }
}

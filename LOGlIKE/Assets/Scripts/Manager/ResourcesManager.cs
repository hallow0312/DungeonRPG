using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager :SingleTon<ResourcesManager>
{
    public T Load<T>(string path) where T : MonoBehaviour
    {
        return Resources.Load<T>(path);
        //�� Unity ������Ʈ ���� Ư�� ��ο� �ִ� ���ҽ��� �ε��ϰ�
        // �� ���ҽ��� MonoBehaviour�� ����ϴ� Ÿ���̶�� �� Ÿ������ ��ȯ����.
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

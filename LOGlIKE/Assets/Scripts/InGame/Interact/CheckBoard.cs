using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckBoard : MonoBehaviour
{
    [SerializeField] int sceneIndex;



    public void SetDungeon(int index)
    {
        sceneIndex = index;
    }

      
    public void EnterDungeon()
    {
        StartCoroutine(SceneController.Instance.AsyncLoad(sceneIndex));
    }
    

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}

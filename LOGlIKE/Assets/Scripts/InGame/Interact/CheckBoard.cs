using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckBoard : MonoBehaviour
{
    public void DungeonSelect()
    {
        StartCoroutine(SceneController.Instance.AsyncLoad(3));
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}

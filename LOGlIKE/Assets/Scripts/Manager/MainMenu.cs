using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Image mainImage;
    public void StartGame()
    {
        mainImage.gameObject.SetActive(false);
        StartCoroutine(SceneController.Instance.AsyncLoad(1));
    }
    public void LoadGame()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

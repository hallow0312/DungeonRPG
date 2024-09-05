using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Image mainImage;
    [SerializeField] AudioClip audioClip;
    public void StartGame()
    {
        SoundManager.Instance.Sound(audioClip);
        mainImage.gameObject.SetActive(false);
        StartCoroutine(SceneController.Instance.AsyncLoad(1));
    }
    public void LoadGame()
    {
        SoundManager.Instance.Sound(audioClip);

    }
    public void ExitGame()
    {
        SoundManager.Instance.Sound(audioClip);
        Application.Quit();
    }
}

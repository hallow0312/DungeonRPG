using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager :SingleTon<SoundManager>
{
    [SerializeField] AudioSource scenerySource;
    [SerializeField] AudioSource effectSource;
    string soundName;
    public void Sound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        soundName = scene.name;
        scenerySource.clip = ResourcesManager.Instance.Load<AudioClip>(soundName);
        scenerySource.loop = true;
        scenerySource.Play();
    }
    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider EffectSlider;

    private void Start()
    {
        MasterSlider.value = SoundManager.Instance.MasterVolume;
        BGMSlider.value = SoundManager.Instance.BGMVolume;
        EffectSlider.value= SoundManager.Instance.EffectVolume;
    }
    public void MasterControl()
    {
        float volume = MasterSlider.value;
        SoundManager.Instance.MasterVolume = volume;
        if (volume == -40f)
        {
            audioMixer.SetFloat("MasterVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", volume);

        }

    }

    public void BGMContorl()
    {
        float volume = BGMSlider.value;
        SoundManager.Instance.BGMVolume=volume;
        if (volume == -40f)
        {
            audioMixer.SetFloat("BGM", -80f);
        }
        else
        {
            audioMixer.SetFloat("BGM", volume);
        }
    }
    public void EffectControl()
    {
        float volume = EffectSlider.value;
        SoundManager.Instance.EffectVolume = volume; 
        if (volume == -40f)
        {
            audioMixer.SetFloat("EffectSound", -80f);
        }
        else
        {
            audioMixer.SetFloat("EffectSound", volume);
        }
    }
   public void ExitVolume()
    {
        gameObject.SetActive(false);
    }
}

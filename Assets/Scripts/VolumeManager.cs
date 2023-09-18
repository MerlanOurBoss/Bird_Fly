using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _myAudio;
    [SerializeField] private Slider _mySlider;

    public void Start()
    {
        LoadSound();
    }
    public void setVolume()
    {
        _myAudio.SetFloat("vol", _mySlider.value);
    }

    public void LoadSound()
    {
        _mySlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SaveSound()
    {
        PlayerPrefs.SetFloat("musicVolume", _mySlider.value);
    }
}

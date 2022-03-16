using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioMixer audioMixer;
    public GameObject SettingScene;

    private void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("VolumeControl", 0.75f);//to set the volume of bgm
        ChangeVolumeSlider();
    }

    public void ChangeVolumeSlider()
    {
        float sliderValue = VolumeSlider.value;
        audioMixer.SetFloat("VolumeControl", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("VolumeControl", sliderValue);
    }

    public void btnQuit()
    {
        SettingScene.SetActive(false);
    }
    public void OpenSetting()
    {
        SettingScene.SetActive(true);
    }
}

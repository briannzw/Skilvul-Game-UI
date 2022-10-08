using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class UIScript : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;

    [SerializeField] private Slider m_Slider;
    [SerializeField] private TMP_Text m_Text;

    [SerializeField] private TMP_Dropdown m_Dropdown;
    [SerializeField] private Toggle m_Toggle;

    private void Start()
    {
        OnCancel();
    }

    public void OnMuteChanged(bool value)
    {
        m_AudioSource.mute = value;
    }

    public void OnVolumeChanged(float value)
    {
        m_AudioSource.volume = value;
        m_Text.text = (Math.Round(value, 2) * 100).ToString() + "%";
    }

    public void OnResolutionChanged(int value)
    {
        switch (value)
        {
            case 0:
                Screen.SetResolution(2560, 1440, false);
                break;
            case 1:
                Screen.SetResolution(1920, 1080, false);
                break;
            case 2:
                Screen.SetResolution(1440, 800, false);
                break;
            case 3:
                Screen.SetResolution(1280, 720, false);
                break;
            case 4:
                Screen.SetResolution(640, 360, false);
                break;
        }
    }

    public void OnApply()
    {
        SaveData saveDat = new SaveData(m_AudioSource.volume, m_Dropdown.value, (m_Toggle.isOn) ? 1 : 0);
        GameManager.instance.SaveSettings(saveDat);
        GameManager.instance.PrintDebug(saveDat);
    }

    public void OnCancel()
    {
        SaveData prevSaveData = GameManager.instance.saveData;
        m_Slider.value = prevSaveData.volume;
        m_Dropdown.value = prevSaveData.resIndex;
        m_Toggle.isOn = (prevSaveData.muted == 1);
    }
}

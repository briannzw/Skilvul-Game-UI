using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TMP_Dropdown m_Dropdown;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("There's more than one GameManager Detected!");
        }

        instance = this;
        saveData = LoadSettings();
    }

    public SaveData saveData;

    private void Start()
    {
        PrintDebug(saveData);
    }

    private SaveData LoadSettings()
    {
        float volume = PlayerPrefs.GetFloat("Settings_Volume", 1);
        int resIndex = PlayerPrefs.GetInt("Settings_Resolution", 1);
        int muted = PlayerPrefs.GetInt("Settings_Mute", 0);

        return new SaveData(volume, resIndex, muted);
    }

    public void SaveSettings(SaveData saveDat)
    {
        PlayerPrefs.SetFloat("Settings_Volume", saveDat.volume);
        PlayerPrefs.SetInt("Settings_Resolution", saveDat.resIndex);
        PlayerPrefs.SetInt("Settings_Mute", saveDat.muted);
        PlayerPrefs.Save();

        saveData = saveDat;
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }

    public void PrintDebug(SaveData saveDat)
    {
        Debug.Log("Volume : " + saveDat.volume + ", Resolution : " + m_Dropdown.options[saveDat.resIndex].text + ", Muted : " + saveDat.muted);
    }
}

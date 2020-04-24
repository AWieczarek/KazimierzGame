using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public GameObject menuUI;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void StartOptions()
    {
        menuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Options()
    {
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToGame()
    {
        Time.timeScale = 1.0f;
        optionsMenuUI.SetActive(false);
    }

    public void BackToStart()
    {
        optionsMenuUI.SetActive(false);
        menuUI.SetActive(true);
    }
}

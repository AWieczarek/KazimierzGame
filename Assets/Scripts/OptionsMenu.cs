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
        menuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToGame()
    {
        optionsMenuUI.SetActive(false);
        menuUI.SetActive(true);
    }

    public void BackToStart()
    {
        optionsMenuUI.SetActive(false);
        menuUI.SetActive(true);
    }
}

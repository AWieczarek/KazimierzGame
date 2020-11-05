using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject CreditsUI;
    public GameObject shopUI;

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
    public void Credits()
    {
        menuUI.SetActive(false);
        CreditsUI.SetActive(true);
        //Time.timeScale = 0f;
    }
    public void Shop()
    {
        menuUI.SetActive(false);
        shopUI.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void BackToGameCredits()
    {
        CreditsUI.SetActive(false);
        menuUI.SetActive(true);
    }
    public void BackToGameShop()
    {
        shopUI.SetActive(false);
        menuUI.SetActive(true);
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

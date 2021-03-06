﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject EndScreenUI;
    public GameObject DevMenu;
    public static GameManager instance;
    public Animator transmition;
    public Animator menu;
    public Animator cameraAnimator;

    public bool isAnimation = false;
    public bool isTutorial = false;

    public float transitionTime = 1f;
    int timeToDialog = 5;
    public GameObject Car;

    public Dialogue[] dialogue1;
    public Dialogue[] dialogue2;
    public Dialogue[] dialogue3;
    public Dialogue[] dialogue4;
    public Dialogue[] dialogue5;
    int previousDialog;

    private void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
    }

    void Start()
    {
        PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("tutorial", 0);
        if (PlayerPrefs.GetInt("tutorial") == 1)
        {
            isTutorial = false;
        }
        else
        {
            isTutorial = true;
        }

        if (isTutorial && SceneManager.GetActiveScene().buildIndex == 1)
        { 
            Invoke("Tutorial", 0.5f);
        }
    }

    private void Update() {
        if (isAnimation && SceneManager.GetActiveScene().buildIndex == 0)
        {
            menu.speed = 0f;
            menu.Play("StartMenuAnimation", 0, 1.0f);
            cameraAnimator.speed = 0f;
            cameraAnimator.Play("CameraAnimation", 0, 1.0f);
        }

        if(Time.time >= timeToDialog && SceneManager.GetActiveScene().buildIndex == 1)
		{
            if(GameObject.Find("RageBarPanel").GetComponent<RageBar>().angry  || isTutorial)
			{
                Invoke("Insults", 5.5f);
            }
            else
			{
                Invoke("Insults", 0.5f);
            }
            
            timeToDialog += Random.Range(10, 20);
        }

        Car.GetComponent<Renderer>().materials[1].color = GameObject.Find("AudioManager").GetComponent<AudioManager>().carColor;
        if (Input.GetMouseButtonDown(0))
        {
            
            if(Input.mousePosition.y > Screen.height/3 && DevMenu.activeSelf)
            {
                DevMenu.SetActive(false);
            }
        }
    }
   public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Time.timeScale = 0;
            GameObject.Find("DistanceBoard").GetComponent<Distance>().UpdateHDistance();
            EndScreenUI.SetActive(true);
        }
        
    }

    public void StartGameForDevelopers(){
        StartCoroutine(LoadLevel(2));
        Time.timeScale = 1.0f;
        }

    public void StartGame(){
        StartCoroutine(LoadLevel(1));
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        Time.timeScale = 1.0f;
    }

    public void Menu()
    {
        StartCoroutine(LoadLevel(0));
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Dev()
    {
        DevMenu.SetActive(true);
    }

    IEnumerator LoadLevel(int levelIndex)
	{
        transmition.SetTrigger("Transmition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
	}

    public void PlayAnimation()
	{
        isAnimation = true;
	}

    void Tutorial()
    {
        isTutorial = false;
        PlayerPrefs.SetInt("tutorial", 1);
        FindObjectOfType<DialogueManager>().TriggerDialogue();
    }
    void Insults()
    {
        int a = Random.Range(1, 5);
        if(a == 1 && a != previousDialog)
		{
            FindObjectOfType<DialogueManager>().conversations = dialogue1;
        }else if (a == 2 && a != previousDialog)
        {
            FindObjectOfType<DialogueManager>().conversations = dialogue2;
        }
        else if (a == 3 && a != previousDialog)
        {
            FindObjectOfType<DialogueManager>().conversations = dialogue3;
        }
        else if (a == 4 && a != previousDialog)
        {
            FindObjectOfType<DialogueManager>().conversations = dialogue4;
        }
        else if (a == 5 && a != previousDialog)
        {
            FindObjectOfType<DialogueManager>().conversations = dialogue5;
        }else
		{
            a = Random.Range(1, 5);
        }
        previousDialog = a;
        FindObjectOfType<DialogueManager>().TriggerDialogue();
    }
}

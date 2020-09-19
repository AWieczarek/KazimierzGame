using System.Collections;
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

    public float transitionTime = 1f;

    private void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

    }
    private void Update() {
        if(Input.GetMouseButtonDown(0))
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
            EndScreenUI.SetActive(true);
        }
        
    }

    public void StartGameForDevelopers(){
        StartCoroutine(LoadLevel(2));
        //SceneManager.LoadScene(2); 
        Time.timeScale = 1.0f;
        }

    public void StartGame(){
        StartCoroutine(LoadLevel(1));
        //SceneManager.LoadScene(1); 
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void Menu()
    {
        StartCoroutine(LoadLevel(0));
        //SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Test()
    {
        Debug.Log("Kupa");

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
}

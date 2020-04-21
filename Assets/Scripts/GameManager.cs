using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject EndScreenUI;
    public GameObject DevMenu;


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

    public void StartGameForDevelopers(){ SceneManager.LoadScene(2); }

    public void StartGame(){ SceneManager.LoadScene(1); }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
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
}

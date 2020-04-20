using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

   public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Przegraleś");
            Time.timeScale = 0;
            //Restart();
            SceneManager.LoadScene(3);
        }
        
    }

    public void StartGameForDevelopers()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void changeCamera()
    {
        
    }
}

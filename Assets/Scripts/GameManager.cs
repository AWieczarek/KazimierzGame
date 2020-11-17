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
    public Animator menu;
    public Animator cameraAnimator;

    public bool isAnimation = false;
    public bool isTutorial = false;

    public float transitionTime = 1f;

    public GameObject Car;

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
        //PlayerPrefs.SetInt("tutorial", 0);
        if (PlayerPrefs.GetInt("tutorial") == 0 && SceneManager.GetActiveScene().buildIndex == 1) isTutorial = true;
        else isTutorial = false;
        if (isTutorial)
        { 
            Invoke("Tutorial", 0.5f);
            isTutorial = false;
            PlayerPrefs.SetInt("tutorial", 1);
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

    public void PlayAnimation()
	{
        isAnimation = true;
	}

    void Tutorial()
    {

        FindObjectOfType<DialogueManager>().TriggerDialogue();
    }
}

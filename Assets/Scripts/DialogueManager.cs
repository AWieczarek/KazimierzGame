using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject DialogueUI;
    public GameObject SwipeControl;

    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartDialogue (Dialogue dialogue)
	{
        animator.SetBool("IsOpen", true);
        Invoke("Freez", 0.5f);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
		}

        DisplayNextSentence();
	}

    public void DisplayNextSentence()
	{
        if(sentences.Count == 0)
		{
            EndDialogue();
            return;
		}

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}

    IEnumerator TypeSentence (string sentence)
	{
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
		{
            dialogueText.text += letter;
            yield return null;
		}
	}

    void EndDialogue()
	{
        animator.SetBool("IsOpen", false);
        //DialogueUI.SetActive(false);
        UnFreez();
    }

    void Freez()
	{
        SwipeControl.GetComponent<SwipeInput>().enabled = false;
        Time.timeScale = 0f;
    }

    void UnFreez()
	{
        SwipeControl.GetComponent<SwipeInput>().enabled = true;
        Time.timeScale = 1.0f;
    }
}

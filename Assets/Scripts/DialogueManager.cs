using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Conversation
{
    public string name; //speaker's name
    [TextArea(1, 3)] public string[] sentences; //their sentences
}

public class DialogueManager : MonoBehaviour
{

    public Dialogue[] conversations;
    private Queue<string> sentences;
    private int index = 0;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject DialogueUI;
    public GameObject SwipeControl;

    public Animator animator;

    public GameObject AdamAvatar;
    public GameObject KazimierzAvatar;

    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartDialogue (Dialogue dialogue)
	{
        animator.SetBool("IsOpen", true);
        Invoke("Freez", 0.5f);
        nameText.text = dialogue.name;
        if(dialogue.name == "Adam")
		{
            KazimierzAvatar.SetActive(false);
            AdamAvatar.SetActive(true);
		}
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
		}

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
	{
        if(sentences.Count <= 0)
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
        index++;
        if (AdamAvatar.activeSelf)
        {
            KazimierzAvatar.SetActive(true);
            AdamAvatar.SetActive(false);
        }

        if (index < conversations.Length)
        {
            StartDialogue(conversations[index]);
            return;
        }
        else
        {
            Invoke("UnFreez", 0.5f);
            animator.SetBool("IsOpen", false);
        }
        
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
    public void TriggerDialogue()
    {
        index = 0;
        StartDialogue(conversations[index]);
    }
}



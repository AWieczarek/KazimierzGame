using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
	public GameObject DialogueUI;

	public void TriggerDialogue()
	{
		//DialogueUI.SetActive(true);
		
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingUp : MonoBehaviour
{


	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			GameObject.Find("ScoreBoard").GetComponent<Score>().score += 1;
			FindObjectOfType<AudioManager>().Play("Manhole");
			Destroy(gameObject);
		}
	}
}

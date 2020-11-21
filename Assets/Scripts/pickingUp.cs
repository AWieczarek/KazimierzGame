using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingUp : MonoBehaviour
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			GameObject.Find("RageBarPanel").GetComponent<RageBar>().rage += Random.Range(5,25);
			FindObjectOfType<AudioManager>().Play("Manhole");
			Destroy(gameObject);
		}
	}
}

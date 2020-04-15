using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingUp : MonoBehaviour
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			Debug.Log("Kutaz");
			Destroy(gameObject);
		}
	}
}

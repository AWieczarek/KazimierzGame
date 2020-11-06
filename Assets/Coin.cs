using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")+Random.Range(10,100));
			FindObjectOfType<AudioManager>().Play("Manhole");
			Destroy(gameObject);
		}
	}
}

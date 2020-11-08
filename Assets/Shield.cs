using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	float boostTime = 5f;
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			GameObject.Find("car").GetComponent<PlayerCollision>().isShield = true;
			
			StartCoroutine(BoostTimeer());
			FindObjectOfType<AudioManager>().Play("Manhole");
			
		}
	}

	IEnumerator BoostTimeer()
	{
		yield return new WaitForSeconds(boostTime);
		GameObject.Find("car").GetComponent<PlayerCollision>().isShield = false;
		Destroy(gameObject);
	}
}

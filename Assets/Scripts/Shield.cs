using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	float boostTime = 5f;
	public MeshRenderer Shieldrenderer;
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			GameObject.Find("car").GetComponent<PlayerCollision>().isShield = true;
			
			StartCoroutine(BoostTimeer());
			FindObjectOfType<AudioManager>().Play("shild");
			Shieldrenderer.enabled = false;
		}
	}

	IEnumerator BoostTimeer()
	{
		yield return new WaitForSeconds(boostTime);
		GameObject.Find("car").GetComponent<PlayerCollision>().isShield = false;
		Destroy(gameObject);
	}
}

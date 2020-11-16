using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
	float boostTime = 5f;
	float speedBoost = 10;
	public MeshRenderer renderer;
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			GameObject.Find("car").GetComponent<PlayerMovement>().speed += speedBoost;

			StartCoroutine(BoostTimeer());
			FindObjectOfType<AudioManager>().Play("boost");
			renderer.enabled = false;
		}
	}

	IEnumerator BoostTimeer()
	{
		yield return new WaitForSeconds(boostTime);
		GameObject.Find("car").GetComponent<PlayerMovement>().speed -= speedBoost;
		Destroy(gameObject);
	}
}

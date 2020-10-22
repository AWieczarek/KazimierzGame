using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBar : MonoBehaviour
{
	public Transform panel;
	public int rage = 0;
	RectTransform panelRectTransform;
	public Animator animator;
	bool angry = false;
	public GameObject Angry;
	public GameObject VAngry;

	bool isDisplayedAngry = true;
	bool isDisplayedVAngry = true;


	private void Start()
	{
		panelRectTransform = panel.GetComponent<RectTransform>();
		RageUpdate();
	}

	private void Update()
	{
		//x+=10;
		RageUpdate();

		if (rage > 50 && rage < 150 && isDisplayedAngry == true)
		{
			angry = true;
			Angry.SetActive(true);
			animator.SetBool("isAngry", angry);
			isDisplayedAngry = false;
			Invoke("AngryOff", 5.0f);
		}

		if (rage > 150 && isDisplayedVAngry == true)
		{
			angry = true;
			VAngry.SetActive(true);
			animator.SetBool("isAngry", angry);
			Invoke("AngryOff", 5.0f);
			isDisplayedVAngry = false;
		}

		
	}


	void RageUpdate()
	{
		if(rage > 200)
		{
			rage -= 200;
			isDisplayedAngry = true;
			isDisplayedVAngry = true;
		}
		panelRectTransform.sizeDelta = new Vector2(30, rage);
	}

	void AngryOff()
	{
		angry = false;
		Angry.SetActive(false);
		VAngry.SetActive(false);
		animator.SetBool("isAngry", angry);
	}
}

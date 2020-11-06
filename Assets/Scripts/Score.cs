using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;
    public TextMeshProUGUI HScore;
    public int highestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        highestScore = PlayerPrefs.GetInt("HScore");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        HScore.text = highestScore.ToString();
    }

    public void UpdateHScore()
	{
        if(score > highestScore)
		{
            highestScore = score;
            PlayerPrefs.SetInt("HScore", highestScore);
		}
	}
}

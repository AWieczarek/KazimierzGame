using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money = 50;
    public TextMeshProUGUI text;
    public string[,] Colours = new string [6,2]{
        {"Blue", "0"},
        {"Yellow", "0"},
        {"Pink", "0"},
        {"Orange", "0"},
        {"Purple", "0"},
        {"Green", "0"},
    };
//
    private void Start()
	{
        for(int i = 0; i<6; i++)
		{
            if (PlayerPrefs.GetInt(Colours[i, 0]) != 0)
            {
                Colours[i, 1] = "1";
            }
        }
        money = PlayerPrefs.GetInt("money", 0);
    }

	void Update()
    {
        text.text = money.ToString() + "$";
    }

    public void Buy(string colour)
	{
        for (int i = 0; i < 6; i++)
        {
            if (colour == Colours[i,0])
            {
                Colours[i, 1] = "1";
                PlayerPrefs.SetInt(colour, 1);
            }
        }
        PlayerPrefs.SetInt("money", money);
    }

    public bool Checker(string color)
	{
        for (int i = 0; i < 6; i++)
        {
            if (color == Colours[i, 0])
            {
                return System.Convert.ToBoolean(Colours[i, 1] == "1" ? 1 : 0);
            }
        }
        return false;
    }
}

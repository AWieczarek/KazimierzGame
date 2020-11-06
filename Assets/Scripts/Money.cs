using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money = 50;
    public TextMeshProUGUI text;
    public bool Blue = false;
    public bool Green = false;
    public bool Orange = false;
    public bool Purple = false;
    public bool Pink = false;
    public bool Yellow = false;

	private void Start()
	{
        if(PlayerPrefs.GetInt("Blue") != 0)
		{
            Blue = true;
        }
        if(PlayerPrefs.GetInt("Green") != 0)
        {
            Green = true;
        }
        if (PlayerPrefs.GetInt("Pink") != 0)
        {
            Pink = true;
        }
        if (PlayerPrefs.GetInt("Purple") != 0)
        {
            Purple = true;
        }
        if (PlayerPrefs.GetInt("Yellow") != 0)
        {
            Yellow = true;
        }
        if (PlayerPrefs.GetInt("Orange") != 0)
        {
            Orange = true;
        }
        money = PlayerPrefs.GetInt("money", 0);
    }

	void Update()
    {
        text.text = money.ToString() + "$";
    }

    public void Buy(string colour)
	{
        
        if(colour == "Blue")
		{
            Blue = true;
            PlayerPrefs.SetInt("Blue", (Blue ? 1 : 0));
        }
        if (colour == "Green")
        {
            Green = true;
            PlayerPrefs.SetInt("Green", (Green ? 1 : 0));
        }
        if (colour == "Purple")
        {
            Purple = true;
            PlayerPrefs.SetInt("Purple", (Purple ? 1 : 0));
        }
        if (colour == "Pink")
        {
            Pink = true;
            PlayerPrefs.SetInt("Pink", (Pink ? 1 : 0));
        }
        if (colour == "Yellow")
        {
            Yellow = true;
            PlayerPrefs.SetInt("Yellow", (Yellow ? 1 : 0));
        }
        if (colour == "Orange")
        {
            Orange = true;
            PlayerPrefs.SetInt("Orange", (Orange ? 1 : 0));
        }
        PlayerPrefs.SetInt("money", money);
    }

    public bool Checker(string color)
	{
        if (color == "Blue")
        {
            return Blue;
        }
        if (color == "Green")
        {
            return Green;
        }
        if (color == "Purple")
        {
            return Purple;
        }
        if (color == "Pink")
        {
            return Pink;
        }
        if (color == "Yellow")
        {
            return Yellow;
        }
        if (color == "Orange")
        {
            return Orange;
        }
        return false;
    }
}

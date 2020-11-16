using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    public GameObject Car;
    public GameObject Image;
    public GameObject PanelBlock;

    public TextMeshProUGUI price;
    float bonus = 0;
    int bonusPrice = 100;
    private void Update()
	{
        if (GameObject.Find("PanelEq").GetComponent<Money>().Checker(Image.GetComponent<UnityEngine.UI.Image>().material.name) == true)
		{
            PanelBlock.SetActive(false);
        }
        bonus = PlayerPrefs.GetFloat("bonus");
        PlayerPrefs.SetInt("bonusPrice", bonusPrice);
        bonusPrice = PlayerPrefs.GetInt("bonusPrice");
        price.text = bonusPrice.ToString();
    }


	public void ChangeColor()
    {       
        Car.GetComponent<Renderer>().materials[1].color = Image.GetComponent<UnityEngine.UI.Image>().material.color;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().carColor = Image.GetComponent<UnityEngine.UI.Image>().material.color;
        //PlayerPrefs.SetString("CarColor", Image.GetComponent<UnityEngine.UI.Image>().material.name);
        PlayerPrefs.SetString("CarColor", ColorUtility.ToHtmlStringRGBA(Image.GetComponent<UnityEngine.UI.Image>().material.color));
    }
    
    public void Unlock()
	{
        if (GameObject.Find("PanelEq").GetComponent<Money>().money >= int.Parse(price.text) && gameObject.name != "bonus")
		{
            GameObject.Find("PanelEq").GetComponent<Money>().money -= int.Parse(price.text);
            PanelBlock.SetActive(false);
            GameObject.Find("PanelEq").GetComponent<Money>().Buy(Image.GetComponent<UnityEngine.UI.Image>().material.name);
		}
		else
		{
            if(GameObject.Find("PanelEq").GetComponent<Money>().money >= int.Parse(price.text))
			{
                GameObject.Find("PanelEq").GetComponent<Money>().money -= int.Parse(price.text);
                PanelBlock.SetActive(false);
                bonus += 1;
                PlayerPrefs.SetFloat("bonus", bonus);
                Debug.Log(PlayerPrefs.GetFloat("bonus"));
                PlayerPrefs.SetInt("money", GameObject.Find("PanelEq").GetComponent<Money>().money);
                bonusPrice += 200;
                PlayerPrefs.SetInt("bonusPrice", bonusPrice);
                price.text = bonusPrice.ToString();
            }
        }
	}
}

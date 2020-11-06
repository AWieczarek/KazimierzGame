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

	private void Update()
	{
        if (GameObject.Find("PanelEq").GetComponent<Money>().Checker(Image.GetComponent<UnityEngine.UI.Image>().material.name) == true)
		{
            PanelBlock.SetActive(false);
        }
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
        if (GameObject.Find("PanelEq").GetComponent<Money>().money >= int.Parse(price.text))
		{
            GameObject.Find("PanelEq").GetComponent<Money>().money -= int.Parse(price.text);
            PanelBlock.SetActive(false);
            GameObject.Find("PanelEq").GetComponent<Money>().Buy(Image.GetComponent<UnityEngine.UI.Image>().material.name);
        }
	}
}

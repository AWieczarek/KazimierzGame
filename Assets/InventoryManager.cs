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



	public void ChangeColor()
    {       
        Car.GetComponent<Renderer>().materials[1].color = Image.GetComponent<UnityEngine.UI.Image>().material.color;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().carColor = Image.GetComponent<UnityEngine.UI.Image>().material.color;
    }
    
    public void Unlock()
	{
        if(GameObject.Find("PanelEq").GetComponent<Money>().money >= int.Parse(price.text))
		{
            GameObject.Find("PanelEq").GetComponent<Money>().money -= int.Parse(price.text);
            PanelBlock.SetActive(false);
		}
	}
}

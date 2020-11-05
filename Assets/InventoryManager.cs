using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject Car;
    public GameObject Image;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeColor()
    {       
        Car.GetComponent<Renderer>().materials[1].color = Image.GetComponent<UnityEngine.UI.Image>().material.color;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().carColor = Image.GetComponent<UnityEngine.UI.Image>().material.color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material[] myMaterials = new Material[7];

    public GameObject Car;

    // Update is called once per frame
    public void Change()
    {
        Car.GetComponent<Renderer>().materials[1].color = myMaterials[0].color;

    }
}

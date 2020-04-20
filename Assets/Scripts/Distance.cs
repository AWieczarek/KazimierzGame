using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Transform playerPosition;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

    }
    

    // Update is called once per frame
    void Update()
    {
        float finalDistance = playerPosition.position.z / 100;
        text.text = finalDistance.ToString("F") + "km";
    }
}

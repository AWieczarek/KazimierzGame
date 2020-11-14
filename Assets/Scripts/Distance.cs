using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Transform playerPosition;
    public TextMeshProUGUI HDistance;
    public float highestDistance = 0;
    float finalDistance;
    public float bonus = 1.0f;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        highestDistance = PlayerPrefs.GetFloat("HDistance");
        bonus = PlayerPrefs.GetFloat("bonus");
    }
    

    // Update is called once per frame
    void Update()
    {
        finalDistance = (playerPosition.position.z * bonus) / 100;
        text.text = finalDistance.ToString("F") + "km";
        HDistance.text = highestDistance.ToString("F") + "km";
    }

    public void UpdateHDistance()
    {
        if (finalDistance > highestDistance)
        {
            highestDistance = finalDistance;
            PlayerPrefs.SetFloat("HDistance", highestDistance);
        }
    }
}

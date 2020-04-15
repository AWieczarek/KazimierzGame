using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public GameObject manager;
    public TextMeshProUGUI speed;

    void Start()
    {
        speed = GetComponent<TextMeshProUGUI>();
        manager = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        speed.text = manager.GetComponent<PlayerMovement>().speed.ToString();
    }
}

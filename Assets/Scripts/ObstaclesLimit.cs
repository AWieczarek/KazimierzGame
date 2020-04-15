using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstaclesLimit : MonoBehaviour
{
    public GameObject manager;
    public TextMeshProUGUI limit;

    void Start()
    {
        limit = GetComponent<TextMeshProUGUI>();
        manager = GameObject.FindGameObjectWithTag("obstacleManager");
    }

    // Update is called once per frame
    void Update()
    {
        limit.text = manager.GetComponent<ObstacleSpawner>().obstaclesLimit.ToString();
    }
}

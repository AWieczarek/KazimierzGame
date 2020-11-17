using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstaclesLimit : MonoBehaviour
{
    public GameObject obstacleManager ;
    public TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        obstacleManager = GameObject.FindGameObjectWithTag("obstacleManager");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = obstacleManager.GetComponent<ObstacleSpawner>().obstaclesLimit.ToString();
    }
}

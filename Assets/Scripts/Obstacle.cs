using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ObstacleSpawner obstacleSpawner;

    private void OnEnable()
    {
        obstacleSpawner = GameObject.FindObjectOfType<ObstacleSpawner>();
    }
    private void OnBecameInvisible()
    {
        obstacleSpawner.RecycleObstacle(this.gameObject);
    }
}

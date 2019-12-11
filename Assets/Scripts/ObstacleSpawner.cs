﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform player;
    private Transform tf;
    public GameObject obstaclePrefab;
    public GameObject[] NumberOfObstacle;
    public GameObject manholePrefab;

    public float timeBetweenWawes = 1f;

    private float timeToSpawn = 2f;

    void Start()
    {
        tf = GetComponent<Transform>();
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            NumberOfObstacle = GameObject.FindGameObjectsWithTag("obstacle");
            if(NumberOfObstacle.Length < 5)
            {
                SpawnObstacle();
                timeToSpawn = Time.time + timeBetweenWawes;
            }

        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int spawnChance = Random.Range(0, 3);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex == i)
            {
                if (spawnChance == 0)
                {
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.Euler(-90, 0, 0));
                    SpawnManhole(randomIndex);
                    tf.position = new Vector3(tf.position.x, tf.position.y, tf.position.z + 130);
                }
                else
                {
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.Euler(-90, 0, 0));
                    tf.position = new Vector3(tf.position.x, tf.position.y, tf.position.z + 130);
                }
            }
        }
    }

    void SpawnManhole(int randomIndex)
    {
        int randomIndex1 = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex1 == i && i != randomIndex)
            {
                Instantiate(manholePrefab, spawnPoints[i].position, Quaternion.Euler(90f, 0f, 0f));
            }
        }
    }

    public void RecycleObstacle(GameObject obstacle)
    {
        Destroy(obstacle);  
    }
}

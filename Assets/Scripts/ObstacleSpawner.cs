using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform player;
    private Transform tf;
    public GameObject[] obstaclePrefab;
    public GameObject[] NumberOfObstacle;
    public GameObject manholePrefab;

    public float timeBetweenWawes = 0f;

    public float timeToSpawn = 1f;

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
            if(NumberOfObstacle.Length < 3)
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
                    Instantiate(obstaclePrefab[1], spawnPoints[i].position, Quaternion.Euler(-90, 0, 0));

                    tf.position = new Vector3(tf.position.x, tf.position.y, tf.position.z + 65);
                }
                else
                {
                    Instantiate(obstaclePrefab[3], spawnPoints[i].position, Quaternion.Euler(-90, 0, 0));
                    SpawnManhole(randomIndex);
                    tf.position = new Vector3(tf.position.x, tf.position.y, tf.position.z + 65);
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
                Instantiate(manholePrefab, spawnPoints[i].position, Quaternion.Euler(-90f, 0f, 0f));
            }
        }
    }

    public void RecycleObstacle(GameObject obstacle)
    {
        Destroy(obstacle);  
    }
}

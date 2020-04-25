using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform playerPosition;
    private Transform obstaclePosition;
    public GameObject[] obstaclePrefab;
    public GameObject[] NumberOfObstacle;
    public GameObject manholePrefab;

    public float obstaclesLimit = 3;

    [SerializeField] private float timeToSpawn = -100f;

    public int distanceBetweenWawes = 65;

    void Start()
    {
        obstaclePosition = GetComponent<Transform>();
        playerPosition = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Time.time >= timeToSpawn/100)
        {
            NumberOfObstacle = GameObject.FindGameObjectsWithTag("obstacle");
            if(NumberOfObstacle.Length < obstaclesLimit)
            {
                SpawnObstacle();
                timeToSpawn = Time.time;
            }

        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length - 1);
        int randomPrefab = Random.Range(0, obstaclePrefab.Length);
        int drawSlot = Random.Range(0,4);
        Vector3 updatePostion = new Vector3(obstaclePosition.position.x, obstaclePosition.position.y, obstaclePosition.position.z + distanceBetweenWawes);
        int sceondObstacle = randomIndex + Random.Range(1,2);
        
        switch(drawSlot)
        {
            case 0:
                SpawnManhole(randomIndex);
                obstaclePosition.position = updatePostion;
                break;
            case 1:
                Instantiate(obstaclePrefab[randomPrefab], spawnPoints[randomIndex].position, Quaternion.Euler(-90, 0, 0));
                obstaclePosition.position = updatePostion;
                break;
            case 2:
                Instantiate(obstaclePrefab[randomPrefab], spawnPoints[randomIndex].position, Quaternion.Euler(-90, 0, 0));
                SpawnManhole(randomIndex);
                obstaclePosition.position = updatePostion;
                break;
            case 3:
                if(sceondObstacle > 3)
                {
                    sceondObstacle = 1;
                }
                Instantiate(obstaclePrefab[randomPrefab], spawnPoints[randomIndex].position, Quaternion.Euler(-90, 0, 0));
                Instantiate(obstaclePrefab[randomPrefab], spawnPoints[sceondObstacle].position, Quaternion.Euler(-90, 0, 0));
                obstaclePosition.position = updatePostion;
                break;

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

    public void AdjustObstaclesLimit(float newLimit)
    {
        obstaclesLimit = newLimit;
    }
}

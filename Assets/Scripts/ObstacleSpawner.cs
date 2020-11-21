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
    public GameObject[] pickupPrefab;
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

        switch (drawSlot)
            {
                case 0:
                    SpawnPickUp(randomIndex);
                    obstaclePosition.position = updatePostion;
                    break;
                case 1:
                    Instantiate(obstaclePrefab[randomPrefab], spawnPoints[randomIndex].position, Quaternion.Euler(-90, 0, 0));
                    obstaclePosition.position = updatePostion;
                    break;
                case 2:
                    Instantiate(obstaclePrefab[randomPrefab], spawnPoints[randomIndex].position, Quaternion.Euler(-90, 0, 0));
                    SpawnPickUp(randomIndex);
                    obstaclePosition.position = updatePostion;
                    break;
                case 3:
                    if (sceondObstacle > 3)
                    {
                        sceondObstacle = 1;
                    }
                    Instantiate(obstaclePrefab[randomPrefab], spawnPoints[randomIndex].position, Quaternion.Euler(-90, 0, 0));
                    Instantiate(obstaclePrefab[randomPrefab], spawnPoints[sceondObstacle].position, Quaternion.Euler(-90, 0, 0));
                    obstaclePosition.position = updatePostion;
                    break;
            }
    }

    void SpawnPickUp(int randomIndex)
    {
        int randomIndex1 = Random.Range(0, spawnPoints.Length +2);
        int randomPrefab = Random.Range(0, pickupPrefab.Length +2);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 pos = new Vector3(spawnPoints[i].position.x, spawnPoints[i].position.y + 1.0f, spawnPoints[i].position.z);

            if (randomIndex1 == i && i != randomIndex)
            {
                switch(randomPrefab)
				{
                    case 0:
                        Instantiate(pickupPrefab[0], spawnPoints[i].position, Quaternion.Euler(-90f, 0f, 0f));
                        break;
                    case 1:
                        Instantiate(pickupPrefab[1], pos, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(pickupPrefab[2], pos, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(pickupPrefab[3], pos, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(pickupPrefab[0], spawnPoints[i].position, Quaternion.Euler(-90f, 0f, 0f));
                        break;
                    case 5:
                        Instantiate(pickupPrefab[0], spawnPoints[i].position, Quaternion.Euler(-90f, 0f, 0f));
                        break;
                }       
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

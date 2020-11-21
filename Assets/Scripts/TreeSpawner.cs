using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TreeSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform player;
    private Transform tf;
    public GameObject[] treePrefab;
    public GameObject[] NumberOfTrees;

    [Header("Varibles")]
    public float treesLimit = 5;

    [SerializeField] private float timeBetweenWawes = 0f;

    [SerializeField] private float timeToSpawn = 1f;

    void Start()
    {
        tf = GetComponent<Transform>();
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            NumberOfTrees = GameObject.FindGameObjectsWithTag("tree");
            if (NumberOfTrees.Length < treesLimit)
            {
                SpawnTrees();
                timeToSpawn = Time.time + timeBetweenWawes;
            }
        }
    }

    void SpawnTrees()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomPrefab = Random.Range(0, treePrefab.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex == i)
            {
                Instantiate(treePrefab[randomPrefab], spawnPoints[i].position, Quaternion.Euler(0, 0, 0));

                tf.position = new Vector3(tf.position.x, tf.position.y, tf.position.z + 65);
            }
        }
    }

    public void RecycleTrees(GameObject trees)
    {
        Destroy(trees);
    }

    public void AdjustTreeLimit(float newLimit)
    {
        treesLimit = newLimit;
    }
}

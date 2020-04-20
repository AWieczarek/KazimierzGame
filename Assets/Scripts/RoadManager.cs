using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefab;
    private float zedOffset;
    void Start()
    {
        for (int i = 0; i < roadPrefab.Length; i++)
        {
            Instantiate(roadPrefab[i], new Vector3(0, 0, i * 13), Quaternion.Euler(-90, 0, 0));
            zedOffset += 13;
        }
    }

    public void RecycleRoad(GameObject road)
    {
        road.transform.position = new Vector3(0, 0, zedOffset);
        zedOffset += 13;    
    }

}

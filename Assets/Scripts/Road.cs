using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private RoadManager roadManager;

    private void OnEnable()
    {
        roadManager = GameObject.FindObjectOfType<RoadManager>();
    }
    private void OnBecameInvisible()
    {
        roadManager.RecycleRoad(this.gameObject);
    }
}

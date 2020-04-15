using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private TreeSpawner treeSpawner;

    private void OnEnable()
    {
        treeSpawner = GameObject.FindObjectOfType<TreeSpawner>();
    }
    private void OnBecameInvisible()
    {
        treeSpawner.RecycleTrees(this.gameObject);
    }
}

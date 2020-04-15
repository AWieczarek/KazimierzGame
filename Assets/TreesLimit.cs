using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreesLimit: MonoBehaviour
{
    public GameObject manager;
    public TextMeshProUGUI limit;

    void Start()
    {
        limit = GetComponent<TextMeshProUGUI>();
        manager = GameObject.FindGameObjectWithTag("treeManager");
    }

    // Update is called once per frame
    void Update()
    {
        limit.text = manager.GetComponent<TreeSpawner>().treesLimit.ToString();
    }
}

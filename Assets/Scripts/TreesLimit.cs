using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreesLimit: MonoBehaviour
{
    public GameObject treeManager;
    public TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        treeManager = GameObject.FindGameObjectWithTag("treeManager");
    }
    void Update()
    {
        text.text = treeManager.GetComponent<TreeSpawner>().treesLimit.ToString();
    }
}

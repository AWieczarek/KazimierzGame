using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class touchTest : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject input;
    int test = 0;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

    }
    

    // Update is called once per frame
    void Update()
    {
        if(input.GetComponent<SwipeInput>().Tap)
        {
            test++;
        }
        text.text = test.ToString();
    }
}

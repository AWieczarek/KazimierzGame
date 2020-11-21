using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        text.text = score.ToString(); 
    }
}

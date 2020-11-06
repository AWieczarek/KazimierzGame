using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money = 50;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = money.ToString() + "$";
    }
}

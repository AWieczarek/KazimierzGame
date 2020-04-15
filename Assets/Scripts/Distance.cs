using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    public TextMeshProUGUI distance;
    public Transform tf;

    void Start()
    {
        distance = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        float finalDistance = tf.position.z / 100;
        distance.text = finalDistance.ToString("F") + "km";
    }
}
